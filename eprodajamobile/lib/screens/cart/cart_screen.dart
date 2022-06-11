import 'package:eprodajamobile/model/cart.dart';
import 'package:eprodajamobile/providers/cart_provider.dart';
import 'package:eprodajamobile/widgets/eprodaja_drawer.dart';
import 'package:eprodajamobile/widgets/master_screen.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:provider/provider.dart';

import '../../providers/order_provider.dart';
import '../../utils/util.dart';

class CartScreen extends StatefulWidget {
  static const String routeName = "/cart";

  const CartScreen({Key? key}) : super(key: key);

  @override
  State<CartScreen> createState() => _CartScreenState();
}

class _CartScreenState extends State<CartScreen> {

  late CartProvider _cartProvider;
  late OrderProvider _orderProvider;
  
  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    
  }

  @override
  void didChangeDependencies() {
    // TODO: implement didChangeDependencies
    super.didChangeDependencies();
    _cartProvider = context.watch<CartProvider>();
    _orderProvider = context.read<OrderProvider>();
  }

  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
        child: Column(
          children: [
            Expanded(child:_buildProductCardList()),
            _buildBuyButton(),
          ],
        ),
      );
  }

  Widget _buildProductCardList() {
    return Container(
      child: ListView.builder(
        itemCount: _cartProvider.cart.items.length,
        itemBuilder: (context, index) {
          return _buildProductCard(_cartProvider.cart.items[index]);
        },
      ),
    );
  }

  Widget _buildProductCard(CartItem item) {
    return ListTile(
      leading: imageFromBase64String(item.product.slika!),
      title: Text(item.product.naziv ?? ""),
      subtitle: Text(item.product.cijena.toString()),
      trailing: Text(item.count.toString()),
    );
  }

  Widget _buildBuyButton() {
    return TextButton(
      child: Text("Buy"),
      onPressed: () async {
        List<Map> items = [];
        _cartProvider.cart.items.forEach((item) {
          items.add({
            "proizvodId": item.product.proizvodId,
            "kolicina": item.count,
          });
        });
        Map order = {
          "items": items,
        };

        await _orderProvider.insert(order);

        _cartProvider.cart.items.clear();
        setState(() {
        });
      },
    );
  }
}