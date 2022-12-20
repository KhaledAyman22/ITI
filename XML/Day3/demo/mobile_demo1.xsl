<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">
<!--<xsl:template match="tutorial">
	<xsl:value-of select="name"/>
	<xsl:text>:::</xsl:text>
	<xsl:value-of select="url"/>
	<xsl:element name="br"/>
</xsl:template>-->
<xsl:template match="tutorials/tutorial">
	<!--<xsl:for-each select="tutorial">-->
		<xsl:value-of select="name"/>
		<xsl:text>:::</xsl:text>
		<xsl:value-of select="url"/>
		<xsl:element name="br"/>
	<!--</xsl:for-each>-->
</xsl:template>
</xsl:stylesheet>
