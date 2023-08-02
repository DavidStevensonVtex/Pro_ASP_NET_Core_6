﻿using System.Collections;

namespace LanguageFeatures.Models
{
    public class ShoppingCart : IEnumerable<Product?>
    {
        public IEnumerable<Product?>? Products { get; set; }

        public IEnumerator<Product?> GetEnumerator() => Products?.GetEnumerator() ??
            Enumerable.Empty<Product?>().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
