import 'package:collection/collection.dart';
import 'package:eprodajamobile/model/cart.dart';
import 'package:flutter/widgets.dart';

import '../model/product.dart';

class CartProvider with ChangeNotifier {
  Cart cart = Cart();
  addToCart(Product product) {
    if (findInCart(product) != null) {
      findInCart(product)?.count++;
    } else {
      cart.items.add(CartItem(product, 1));
    }
    
    notifyListeners();
  }

  removeFromCart(Product product) {
    cart.items.removeWhere((item) => item.product.proizvodId == product.proizvodId);
    notifyListeners();
  }

  CartItem? findInCart(Product product) {
    CartItem? item = cart.items.firstWhereOrNull((item) => item.product.proizvodId == product.proizvodId);
    return item;
  }
}