<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">
<xsl:template match="xslTutorial">
	<xsl:for-each select="SECTION">
		<xsl:choose>
			<xsl:when test="SUMMARY">
				<xsl:text>SUMMARY :: </xsl:text>
				<xsl:value-of select="SUMMARY"/>
				<xsl:element name="br"/>
			</xsl:when>
			<xsl:otherwise>
				<xsl:for-each select="DATA">
					<xsl:text>DATA ::</xsl:text>
					<xsl:value-of select="."/>
					<xsl:element name="br"/>
				</xsl:for-each>				
			</xsl:otherwise>
		</xsl:choose>
	</xsl:for-each>
</xsl:template>
</xsl:stylesheet>
