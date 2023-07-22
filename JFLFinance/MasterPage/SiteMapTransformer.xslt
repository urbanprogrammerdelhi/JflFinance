<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <xsl:apply-templates />
  </xsl:template>
  <xsl:template match="/dsMenues">
    <xsl:element name="siteMap"
      namespace="http://schemas.microsoft.com/AspNet/SiteMap-File-1.0">
      <!-- First Table in Heirarchy -->
      <xsl:for-each select="./*[starts-with(local-name(), 'Table')]">
        <xsl:element name="siteMapNode"
          namespace="http://schemas.microsoft.com/AspNet/SiteMap-File-1.0">
          <xsl:call-template name="transformElementsToAttributes" />
          <!-- Second Table in Heirarchy -->
          <xsl:for-each select="./*[starts-with(local-name(), 'Table')]">
            <xsl:element name="siteMapNode"
              namespace="http://schemas.microsoft.com/AspNet/SiteMap-File-1.0">
              <xsl:call-template name="transformElementsToAttributes" />
              <!-- Third Table in Heirarchy -->
              <xsl:for-each select="./*[starts-with(local-name(), 'Table')]">
                <xsl:element name="siteMapNode"
                  namespace="http://schemas.microsoft.com/AspNet/SiteMap-File-1.0">
                  <xsl:call-template name="transformElementsToAttributes" />
                  <!-- Fourth Table in Heirarchy -->
                  <xsl:for-each select="./*[starts-with(local-name(), 'Table')]">
                    <xsl:element name="siteMapNode"
                      namespace="http://schemas.microsoft.com/AspNet/SiteMap-File-1.0">
                      <xsl:call-template name="transformElementsToAttributes" />
                      <!-- Fifth Table in Heirarchy -->
                      <xsl:for-each select="./*[starts-with(local-name(), 'Table')]">
                        <xsl:element name="siteMapNode"
                          namespace="http://schemas.microsoft.com/AspNet/SiteMap-File-1.0">
                          <xsl:call-template name="transformElementsToAttributes" />
                          <!-- Sixth Table in Heirarchy -->
                          <xsl:for-each select="./*[starts-with(local-name(), 'Table')]">
                            <xsl:element name="siteMapNode"
                               namespace="http://schemas.microsoft.com/AspNet/SiteMap-File-1.0">
                              <xsl:call-template name="transformElementsToAttributes" />
                            </xsl:element>
                          </xsl:for-each>
                        </xsl:element>
                      </xsl:for-each>
                    </xsl:element>
                  </xsl:for-each>
                </xsl:element>
              </xsl:for-each>
            </xsl:element>
          </xsl:for-each>
        </xsl:element>
      </xsl:for-each>
    </xsl:element>
  </xsl:template>
  <xsl:template name="transformElementsToAttributes">
    <xsl:attribute name="PageName">
      <xsl:value-of select="PageName"/>
    </xsl:attribute>
    <xsl:attribute name="MenuHeadCode">
      <xsl:value-of select="MenuHeadCode"/>
    </xsl:attribute>
    <xsl:attribute name="MenuHeadName">
      <xsl:value-of select="MenuHeadName"/>
    </xsl:attribute>
  </xsl:template>
</xsl:stylesheet>