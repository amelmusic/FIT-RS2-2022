import 'package:eprodajamobile/providers/product_provider.dart';
import 'package:eprodajamobile/utils/util.dart';
import 'package:flutter/material.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/src/widgets/framework.dart';
import 'package:intl/intl.dart';
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
  TextEditingController _searchController = TextEditingController();

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
              _buildProductSearch(),
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

  Widget _buildProductSearch() {
    return Row(
      children: [
        Expanded(
          child: Container(
            padding: EdgeInsets.symmetric(horizontal: 20, vertical: 10),
            child: TextField(
              controller: _searchController,
              onSubmitted: (value) async {
                var tmpData = await _productProvider?.get({'naziv': value});
                setState(() {
                  data = tmpData!;
                });
              },
              decoration: InputDecoration(
                  hintText: "Search",
                  prefixIcon: Icon(Icons.search),
                  border: OutlineInputBorder(
                      borderRadius: BorderRadius.circular(10),
                      borderSide: BorderSide(color: Colors.grey))),
            ),
          ),
        ),
        Container(
          padding: EdgeInsets.symmetric(horizontal: 20, vertical: 10),
          child: IconButton(
            icon: Icon(Icons.filter_list),
            onPressed: () async {
                var tmpData = await _productProvider?.get({'naziv': _searchController.text});
                setState(() {
                  data = tmpData!;
                });
            },
          ),
        )
      ],
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
                  Text(x.naziv ?? ""),
                  Text(formatNumber(x.cijena)),
                ],
              ),
            ))
        .cast<Widget>()
        .toList();

    return list;
  }
}
