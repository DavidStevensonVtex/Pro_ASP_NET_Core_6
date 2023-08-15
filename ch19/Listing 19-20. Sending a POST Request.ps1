Invoke-RestMethod http://localhost:5000/api/products -Method POST `
    -Body (@{ Name="Boot Laces"; Price=19.99; CategoryId=2; SupplierId=2} | `
    ConvertTo-Json) -ContentType "application/json"

    # productId  : 13
    # name       : Boot Laces
    # price      : 19.99
    # categoryId : 2
    # category   :
    # supplierId : 2
    # supplier   :