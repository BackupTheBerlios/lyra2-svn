/**
 * <p>Title: Converter</p>
 * <p>Description: (TitleTable, SongList) -> LTX-File</p>
 * <p>Copyright: Copyright (c) 2004</p>
 * <p>Company: private</p>
 * @author ogirard
 * @version 1.0
 */
import java.io.*;
import java.util.*;
import java.nio.charset.*;

public class LTXConverter
{
  private String tablefile;
  private String infile;
  private String outfile;
  private Hashtable hash;

  public LTXConverter(String table, String in, String out)
  {
    this.tablefile = table;
    this.infile = in;
    this.outfile = out;
    this.hash = new Hashtable();
  }

  private String cleanString(String str)
  {
    char[] strchr = str.toCharArray();
    int i = 0;
    int j = strchr.length - 1;
    while (i < strchr.length &&
           (strchr[i] == ' ' || strchr[i] == '\n' || strchr[i] == '\t')) {
      i++;
    }
    while (j >= 0 &&
           (strchr[j] == ' ' || strchr[j] == '\n' || strchr[j] == '\t')) {
      j--;
    }
    if (i > j) {
      return "";
    }
    else {
      return str.substring(i, j + 1);
    }
  }

  private boolean first = true;
  public void run()
  {
    try {
      FileReader fr = new FileReader(tablefile);
      LineNumberReader lr = new LineNumberReader(fr);
      String str;
      while ( (str = lr.readLine()) != null) {
        String[] strls = str.split("\t");
        String nr = this.cleanString(strls[strls.length - 1]);
        String title = this.cleanString(str.substring(0,
            str.length() - nr.length()));
        this.hash.put(nr, title);
      }
      lr.close();
      System.out.println("\nrunning...");
      System.out.println(Integer.toString(this.hash.size()) + " titles read.");

      FileReader ifr = new FileReader(infile);
      File out = new File(outfile);
      OutputStreamWriter writer = new OutputStreamWriter(
          new FileOutputStream(out), "UTF-8");
      LineNumberReader ilr = new LineNumberReader(ifr);
      String istr;
      int nr = -1;
      int count = 0;
      int nrofsongs = 0;
      while ( (istr = ilr.readLine()) != null) {
        istr = this.cleanString(istr);
        if ( (nr = this.isNumber(istr)) != -1) {
          count = 0;
          if (!this.first) {
            writer.write("#END\n\n\n");
            nrofsongs++;
          }
          else {
            this.first = false;
          }
          String nrstr = Integer.toString(nr);
          String title = " ";
          try {
            if ( (title = (String)this.hash.get(nrstr)) == null) {
              title = " ";
            }

          }
          catch (Exception e) {
            title = " ";
          }
          writer.write(nrstr + " " + title + "\n");
        }
        else {
          String nl = "";
          if (istr == "") {
            count++;
          }
          else {
            for (int j = 0; j < count; j++) {
              nl += "\n";
            }
            count = 0;
            writer.write(nl + istr + "\n");
          }
        }
      }
      writer.write("#END\n\n\n");
      nrofsongs++;
      writer.close();
      ilr.close();
      System.out.println(Integer.toString(nrofsongs) +
                         " songs read and formatted.");
      System.out.println("SUCCESSFUL! :-)\n");
      System.out.println("You can find the output LTX-File at:");
      System.out.println(out.getAbsolutePath());
      System.out.println("This LTX-file is UTF-8-encoded.\n" +
                         "\nASSURE that your OWN files are also " +
                         "UTF-8-encoded, when you want to\n" +
                         "import them into lyra!");
    }
    catch (IOException e) {
      System.out.println("Input-files NOT FOUND!");
      System.err.println(e);
    }

  }

  public int isNumber(String line)
  {
    if (line != "") {
      char[] cline = line.toCharArray();
      if ((cline.length > 0) && (
          cline[0] == '0' ||
          cline[0] == '1' ||
          cline[0] == '2' ||
          cline[0] == '3' ||
          cline[0] == '4' ||
          cline[0] == '5' ||
          cline[0] == '6' ||
          cline[0] == '7' ||
          cline[0] == '8' ||
          cline[0] == '9')) {

        int nr = 0;
        for (int i = 0; i < cline.length; i++) {
          if (cline[i] == '\n' || cline[i] == '\t') {
            cline[i] = ' ';
          }
        }

        try {
          nr = Integer.parseInt(this.cleanString(String.valueOf(cline).split(
              " ")[0]));
        }
        catch (NumberFormatException e) {
          return -1;
        }
        return nr;
      }
    }
    return -1;
  }

  public static void main(String[] args)
  {
    System.out.println("CONVERTER TOOL FOR LYRA\n" + "~~~~~~~~~~~~~~~~~~~~~~~\n");
    System.out.println("Please indicate the paths of your input-files.\n" +
                       "(relative to {converter-dir} or absolute)\n\n");
    System.out.println("The DEFAULT paths of the input-files are:\n" +
                    "   {converter-dir}\\in.txt and {converter-dir}\\table.txt\n" +
                    "   (just press enter to take the default-values)\n");

    LineNumberReader console = new LineNumberReader(
        new InputStreamReader(System.in));
    String in = "";
    String table = "";
    System.out.print("  >> IN File (texts): ");
    try {
      if ((in = console.readLine()).trim().length()==0) {
        in = "in.txt"; // default
      }
    }
    catch (IOException ex) {
      ex.printStackTrace();
    }
    System.out.print("  >> TABLE File (titles): ");
    try {
      if ( (table = console.readLine()).trim().length() == 0) {
        table = "table.txt"; // default
      }
    }
    catch (IOException ex) {
      ex.printStackTrace();
    }
    LTXConverter converter = new LTXConverter(table, in, "out.ltx");
    converter.run();
  }
}