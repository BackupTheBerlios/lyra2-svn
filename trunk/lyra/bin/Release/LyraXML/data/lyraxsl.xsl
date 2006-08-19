<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

<xsl:template match="/">
  <html>
  <head>
    <title>lyra Songliste</title>
    <meta name="DC.Title" content="lyra Songliste" />
    <meta name="DC.Date" content="2006/07/16" />
    <meta name="DC.Format" content="text/xsl" />
    <meta name="DC.Language" content="de" />
    <meta name="DC.Rights" content="Alle Rechte dem Autor vorbehalten." />
    <meta name="generator" content="lyra v1.1 html-generator" />

    <style type="text/css">
      td {font-family:verdana;
          font-size:10pt;
          color:#000000;
          text-align:left;
          border-width:1px;}

      td.right {text-align:right;
                color:#346098;
                font-weight: bold;
                padding-right:10px; }

      h1 {font-family:verdana;font-size:13pt;color:#346098;}
      h2 {font-family:verdana;font-size:12pt;color:#666666;}
          
      body {font-family:verdana; font-size: 10pt; background-color:#ffffff;}


      a         {font-family:verdana;
                 text-decoration:none;
                 background-color:transparent;
                 font-size:10pt; }
      a:link    {color:#000000;}
      a:visited {color:#000000;}
      a:active  {color:#cc0000;}
      a:hover   {color:#cc0000;}
      span.info {color:#AAAAAA;}
      
      a.top         {font-size:7pt; }


    </style>

  </head>
  
  <body>
    <img src="logo_kl.jpg" hspace="15" align="left" />
    <br />
    <h1>lyra Songliste</h1>
    <span class="info">2006/07/16<br />
<br />
ganze Liste
    </span><br />
<br />
    <br clear="all" />
    <a name="top" />
    <h2>Inhaltsverzeichnis</h2>
    <ul>
    <table cellspacing="0" cellpadding="0">
    <xsl:for-each select="/lyra/Song">
    <xsl:sort select="Number" data-type="number" />
      <tr>
        <td class="right"><xsl:value-of select="Number"/></td>
        <td>
	  		<script type="text/javascript">
          document.write("&lt;a href=\"#<xsl:value-of select="@id"/>\"&gt;");
 					document.write("<xsl:value-of select="Title"/>");
          document.write("&lt;/a&gt;");
        </script>
        </td>
      </tr>
    </xsl:for-each>
    </table>
    </ul>
    <br />
    <h2>Liedtexte</h2>    
    <ul>
    <xsl:for-each select="/lyra/Song">
    <xsl:sort select="Number" data-type="number" />
    <table cellspacing="1" cellpadding="2" bgcolor="#aaaaaa" width="800">
    <tr>
      <td width="50" bgcolor="dddddd">
        <script type="text/javascript">
          document.write("&lt;a name=\"<xsl:value-of select="@id"/>\"/&gt;");
        </script>
        <b><xsl:value-of select="Number"/></b>
      </td>
      <td width="734" bgcolor="#dddddd"><xsl:value-of select="Title"/></td>
     <td width="16" bgcolor="#dddddd"><a class="top" href="#top">top</a></td>
    </tr>
    <tr>
      <td width="800" colspan="3" bgcolor="#f4f4f4"><xsl:value-of select="Text" /></td>
    </tr>
    <xsl:for-each select="Translations/Translation">
    <tr>
    	<td width="50" bgcolor="#f4f4f4"></td>
    	<td width="750" colspan="2" bgcolor="#dddddd">
    		<xsl:value-of select="Title" />
    	</td>
    </tr>
    <tr>
    	<td colspan="3" bgcolor="#f4f4f4">
    		<xsl:value-of select="Text" />
    	</td>
    </tr>
    </xsl:for-each>
    </table><br />
    </xsl:for-each>
    </ul>
    
  </body>
  </html>
</xsl:template>

</xsl:stylesheet>
