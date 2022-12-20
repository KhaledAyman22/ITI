<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">
<xsl:template match="food_list">

<table>
	<tbody>
		<tr>
			<th>position</th>
			<th>name</th>
			<th>carbs</th>
			<th>fiber</th>
			<th>fat</th>
			<th>kj</th>
		</tr>
		<xsl:for-each select="food_item[kj_per_serving &lt; 1000]">
		<!--[@type='fruit' or @type='grain']-->
		<xsl:sort select="kj_per_serving" order="descending" data-type="number"/>
			<!--<xsl:choose>
				<xsl:when test="@type='fruit'">-->
					<tr style="background-color:red">
						<td><xsl:value-of select="position()"/></td>
						<td><xsl:value-of select="name"/></td>
						<td><xsl:value-of select="carbs_per_serving*3"/></td>
						<td><xsl:value-of select="fiber_per_serving"/></td>
						<td><xsl:value-of select="fat_per_serving"/></td>
						<td><xsl:value-of select="kj_per_serving"/></td>
					</tr>
				<!--</xsl:when>
				<xsl:otherwise>
					<tr style="background-color:blue">
						<td><xsl:value-of select="position()"/></td>
						<td><xsl:value-of select="name"/></td>
						<td><xsl:value-of select="carbs_per_serving *3"/></td>
						<td><xsl:value-of select="fiber_per_serving"/></td>
						<td><xsl:value-of select="fat_per_serving"/></td>
						<td><xsl:value-of select="kj_per_serving"/></td>
					</tr>
				</xsl:otherwise>
			</xsl:choose>-->
		</xsl:for-each>
	</tbody>
</table>
</xsl:template>

</xsl:stylesheet>
