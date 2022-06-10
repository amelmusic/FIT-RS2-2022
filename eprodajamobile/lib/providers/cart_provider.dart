import 'package:eprodajamobile/model/cart.dart';
import 'package:flutter/widgets.dart';

import '../model/product.dart';

class CartProvider with ChangeNotifier {
  Cart cart = Cart();
  addToCart(Product product) {
    if (findInCart(product) != null) {
      findInCart(product).count++;
    } else {
      cart.items.add(CartItem(product, 1));
    }
    
    notifyListeners();
  }

  removeFromCart(Product product) {
    cart.items.removeWhere((item) => item.product.proizvodId == product.proizvodId);
    notifyListeners();
  }

  findInCart(Product product) {
    return cart.items.firstWhere((item) => item.product.proizvodId == product.proizvodId);
  }
}