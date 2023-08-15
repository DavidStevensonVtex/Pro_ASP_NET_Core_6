Invoke-WebRequest http://localhost:5000/api/products/1 | Select-Object Content

# Content
# -------
# {"productId":1,"name":"Green Kayak","price":275.00,"categoryId":1,"category":null,"supplierId":1,"supplier":null}