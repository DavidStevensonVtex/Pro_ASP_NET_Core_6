$r = Invoke-WebRequest http://localhost:5000/api/content/object 
# $r
"Status Code: $($r.StatusCode)   Content-Type: $($r.Headers["Content-Type"])"
"Content: $($r.Content)"

# Status Code: 200   Content-Type: application/json; charset=utf-8
# Content: {"productId":1,"name":"Kayak","price":275.00,"categoryId":1,"supplierId":1}