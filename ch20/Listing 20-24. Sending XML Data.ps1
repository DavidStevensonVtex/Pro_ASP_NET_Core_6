Invoke-RestMethod http://localhost:5000/api/content -Method POST `
    -Body "<ProductBindingTarget xmlns=`"http://schemas.datacontract.org/2004/07/WebApp.Models`"><CategoryId>1</CategoryId><Name>Kayak</Name><Price>275.00</Price><SupplierId>1</SupplierId></ProductBindingTarget>"  `
    -ContentType "application/xml"

    # XML: Kayak