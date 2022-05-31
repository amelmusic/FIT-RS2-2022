import 'dart:convert';
import 'dart:io';
import 'dart:async';
import 'package:eprodajamobile/model/product.dart';
import 'package:http/http.dart';
import 'package:http/io_client.dart';
import 'package:flutter/foundation.dart';

class ProductProvider with ChangeNotifier {

  HttpClient client = new HttpClient();
  IOClient? http;
  ProductProvider() {
    print("called ProductProvider");
    client.badCertificateCallback =(cert, host, port) => true;
    http = IOClient(client);
    
  }

  Future<List<Product>> get(dynamic searchObject) async {
    print("called ProductProvider.GET METHOD");
    var url = Uri.parse("https://10.0.2.2:7192/Proizvodi");

    String username = "admin";
    String password = "admin";

    String basicAuth = "Basic ${base64Encode(utf8.encode('$username:$password'))}";

    var headers = {
      "Content-Type": "application/json",
      "Authorization": basicAuth
    };

    var response = await http!.get(url, headers: headers);

    if (response.statusCode < 400) {
      var data = jsonDecode(response.body);
      List<Product> list = data.map((x) => Product.fromJson(x)).cast<Product>().toList();
      return list;
    } else {
      throw Exception("User not allowed");
    }
  }
}