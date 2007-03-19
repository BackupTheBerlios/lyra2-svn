"<?xml version=\"1.0\" encoding=\"utf-8\"?>"\n"+
"<xsl:stylesheet version=\"1.0\" xmlns:xsl=\"http://www.w3.org/1999/XSL/Transform\">\n\n"+
"<xsl:template match=\"/\">\n"+
"  <html>\n"+
"  <head>\n"+
"    <title>lyra Songliste</title>\n"+
"    <meta name=\"DC.Title\" content=\"lyra Songliste\" />\n"+
"    <meta name=\"DC.Date\" content=\"2004-02-09\" />\n"+
"    <meta name=\"DC.Format\" content=\"text/xsl\" />\n"+
"    <meta name=\"DC.Language\" content=\"de\" />\n"+
"    <meta name=\"DC.Rights\" content=\"Alle Rechte dem Autor vorbehalten.\" />\n"+
"    <meta name=\"generator\" content=\"lyra v1.1 html-generator\" />\n\n"+
"    <style type=\"text/css\">\n"+
"      td {font-family:verdana;\n"+
"          font-size:10pt;\n"+
"          color:#000000;\n"+
"          text-align:left;\n"+
"          border-width:1px;}\n\n"+
"      td.right {text-align:right;\n"+
"                color:#346098;\n"+
"                font-weight: bold;\n"+
"                padding-right:10px; }\n\n"+
"      h1 {font-family:verdana;font-size:13pt;color:#346098;}\n"+
"      h2 {font-family:verdana;font-size:12pt;color:#666666;}\n"+
"          \n"+
"      body {font-family:verdana; font-size: 10pt; background-color:#ffffff;}\n\n\n"+
"      a         {font-family:verdana;\n"+
"                 text-decoration:none;\n"+
"                 background-color:transparent;\n"+
"                 font-size:10pt; }\n"+
"      a:link    {color:#000000;}\n"+\n"+
"      a:visited {color:#000000;}\n"+
"      a:active  {color:#cc0000;}\n"+
"      a:hover   {color:#cc0000;}\n"+
"      \n"+
"      a.top         {font-size:7pt; }\n\n\n"+
"    </style>\n\n"+
"  </head>\n"+
"  \n"+
"  <body>\n"+
"    <img src=\"lyra_logo.jpg\" hspace=\"15\" align=\"left\" />\n"+
"    <br />\n"+
"    <h1>lyra Songliste</h1>\n"+
"    9.Februar 2004\n"+
"    <br clear=\"all\" />\n"+
"    <a name=\"top\" />\n"+
"    <h2>Inhaltsverzeichnis</h2>\n"+
"    <ul>\n"+
"    <table cellspacing=\"0\" cellpadding=\"0\">\n"+
"    <xsl:for-each select=\"/lyra/Songs/Song\">\n"+
"    <xsl:sort select=\"Number\" data-type=\"number\" />\n"+
"      <tr>\n"+
"        <td class=\"right\"><xsl:value-of select=\"Number\"/></td>\n"+
"        <td>\n"+
"	  		<script type=\"text/javascript\">\n"+
"          document.write(\"&lt;a href=\\"#<xsl:value-of select=\"@id\"/>\\"&gt;\");\n"+
" 					document.write(\"<xsl:value-of select=\"Title\"/>\");\n"+
"          document.write(\"&lt;/a&gt;\");\n"+
"        </script>\n"+
"        </td>\n"+
"      </tr>\n"+
"    </xsl:for-each>\n"+
"    </table>\n"+
"    </ul>\n"+
"    <br />\n"+
"    <h2>Liedtexte</h2>    \n"+
"    <ul>\n"+
"    <xsl:for-each select=\"/lyra/Songs/Song\">\n"+
"    <xsl:sort select=\"Number\" data-type=\"number\" />\n"+
"    <table cellspacing=\"1\" cellpadding=\"2\" bgcolor=\"#aaaaaa\" width=\"800\">\n"+
"    <tr>\n"+
"      <td width=\"50\" bgcolor=\"dddddd\">\n"+
"        <script type=\"text/javascript\">\n"+
"          document.write(\"&lt;a name=\\"<xsl:value-of select=\"@id\"/>\\"/&gt;\");\n"+
"        </script>\n"+
"        <b><xsl:value-of select=\"Number\"/></b>\n"+
"      </td>\n"+
"      <td width=\"734\" bgcolor=\"#dddddd\"><xsl:value-of select=\"Title\"/></td>\n"+
"     <td width=\"16\" bgcolor=\"#dddddd\"><a class=\"top\" href=\"#top\">top</a></td>\n"+
"    </tr>\n"+
"    <tr>\n"+
"      <td width=\"800\" colspan=\"3\" bgcolor=\"#f0f4ff\"><xsl:value-of select=\"Text\"+/></td>\n"+
"    </tr>\n"+
"    <xsl:for-each select=\"Translations/Translation\">\n"+
"    <tr>\n"+
"    	<td></td>\n"+
"    	<td colspan=\"2\" bgcolor=\"#dddddd\">\n"+
"    		<xsl:value-of select=\"Title\" />\n"+
"    	</td>\n"+
"    </tr>\n"+
"    <tr>\n"+
"    	<td colspan=\"3\" bgcolor=\"#dddddd\">\n"+
"    		<xsl:value-of select=\"Text\" />\n"+
"    	</td>\n"+
"    </tr>\n"+
"    </xsl:for-each>\n"+
"    </table><br />\n"+
"    </xsl:for-each>\n"+
"    </ul>\n"+
"    \n"+
"  </body>\n"+
"  </html>\n"+
"</xsl:template>\n"+
"\n"+
"</xsl:stylesheet>\n";