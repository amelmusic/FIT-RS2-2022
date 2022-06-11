import 'package:flutter/cupertino.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';

import '../../widgets/master_screen.dart';

class ProductDetailsScreen extends StatefulWidget {
  static const String routeName = "/product_details";
  String id;
  ProductDetailsScreen(this.id, {Key? key}) : super(key: key);

  @override
  State<ProductDetailsScreen> createState() => _ProductDetailsScreenState();
}

class _ProductDetailsScreenState extends State<ProductDetailsScreen> {
  @override
  Widget build(BuildContext context) {
    return MasterScreenWidget(
      child: Center(child: Text(this.widget.id),),
    );
  }
}