import 'package:eprodajamobile/providers/product_provider.dart';
import 'package:eprodajamobile/utils/util.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:provider/provider.dart';

import '../../model/product.dart';

class ProductListScreen extends StatefulWidget {
  static const String routeName = "/product";

  const ProductListScreen({Key? key}) : super(key: key);

  @override
  State<ProductListScreen> createState() => _ProductListScreenState();
}

class _ProductListScreenState extends State<ProductListScreen> {
  ProductProvider? _productProvider = null;
  List<Product> data = [];

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _productProvider = context.read<ProductProvider>();

    print("called initState");
    loadData();
  }

  Future loadData() async {
    var tmpData = await _productProvider?.get(null);
    setState(() {
      data = tmpData!;
    });
  }

  @override
  Widget build(BuildContext context) {
    print("called build $data");
    return Scaffold(
      body: SafeArea(
        child: SingleChildScrollView(
        child: Container(
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              _buildHeader(),
              Container(
                height: 200,
                child: GridView(
                  gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
                      crossAxisCount: 1,
                      childAspectRatio: 4 / 3,
                      crossAxisSpacing: 20,
                      mainAxisSpacing: 30),
                  scrollDirection: Axis.horizontal,
                  children: _buildProductCardList(),
                ),
              )
            ],
          ),
        ),
      ),
      ),
    );
  }

  Widget _buildHeader() {
    return Container(
      padding: EdgeInsets.symmetric(horizontal: 20, vertical: 10),
      child: Text("Products", style: TextStyle(color: Colors.grey, fontSize: 40, fontWeight: FontWeight.w600),),
    );
  }

  List<Widget> _buildProductCardList() {
    if (data.length == 0) {
      return [Text("Loading...")];
    }

    List<Widget> list = data
        .map((x) => Container(
              
              child: Column(
                children: [
                  Container(
                    height: 100,
                    width: 100,
                    child: imageFromBase64String(x.slika!),
                  ),
                  Text(x.naziv ?? "")
                ],
              ),
            ))
        .cast<Widget>()
        .toList();

    return list;
  }
}
