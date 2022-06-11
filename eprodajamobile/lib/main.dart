import 'package:eprodajamobile/providers/cart_provider.dart';
import 'package:eprodajamobile/providers/order_provider.dart';
import 'package:eprodajamobile/providers/product_provider.dart';
import 'package:eprodajamobile/screens/cart/cart_screen.dart';
import 'package:eprodajamobile/screens/products/product_details_screen.dart';
import 'package:eprodajamobile/screens/products/product_list_screen.dart';
import 'package:eprodajamobile/utils/util.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import 'providers/user_provider.dart';

void main() => runApp(MultiProvider(
      providers: [
        ChangeNotifierProvider(create: (_) => ProductProvider()),
        ChangeNotifierProvider(create: (_) => UserProvider()),
        ChangeNotifierProvider(create: (_) => CartProvider()),
        ChangeNotifierProvider(create: (_) => OrderProvider()),
      ],
      child: MaterialApp(
        debugShowCheckedModeBanner: true,
        theme: ThemeData(
          // Define the default brightness and colors.
          brightness: Brightness.light,
          primaryColor: Colors.deepPurple,
          textButtonTheme: TextButtonThemeData(
                style: TextButton.styleFrom(
                    primary: Colors.deepPurple,
                    textStyle: const TextStyle(
                        fontSize: 24,
                        fontWeight: FontWeight.bold,
                        fontStyle: FontStyle.italic))),

          // Define the default `TextTheme`. Use this to specify the default
          // text styling for headlines, titles, bodies of text, and more.
          textTheme: const TextTheme(
            headline1: TextStyle(fontSize: 72.0, fontWeight: FontWeight.bold),
            headline6: TextStyle(fontSize: 36.0, fontStyle: FontStyle.italic),
           
          ),
        ),
        home: HomePage(),
        onGenerateRoute: (settings) {
          if (settings.name == ProductListScreen.routeName) {
            return MaterialPageRoute(
                builder: ((context) => ProductListScreen()));
          } else if (settings.name == CartScreen.routeName) {
            return MaterialPageRoute(
                builder: ((context) => CartScreen()));
          }

          var uri = Uri.parse(settings.name!);
          if (uri.pathSegments.length == 2 &&
              "/${uri.pathSegments.first}" == ProductDetailsScreen.routeName) {
            var id = uri.pathSegments[1];
            return MaterialPageRoute(builder: (context) => ProductDetailsScreen(id));
          }

        },
      ),
    ));

class HomePage extends StatelessWidget {
  TextEditingController _usernameController = TextEditingController();
  TextEditingController _passwordController = TextEditingController();
  late UserProvider _userProvider;

  @override
  Widget build(BuildContext context) {
    _userProvider = Provider.of<UserProvider>(context, listen: false);

    return Scaffold(
      appBar: AppBar(
        title: Text("Flutter Row Example"),
      ),
      body: SingleChildScrollView(
        child: Column(
          children: [
            Container(
              height: 400,
              decoration: BoxDecoration(
                  image: DecorationImage(
                      image: AssetImage("assets/images/background.png"),
                      fit: BoxFit.fill)),
              child: Stack(children: [
                Positioned(
                    left: 120,
                    top: 0,
                    width: 80,
                    height: 120,
                    child: Container(
                        decoration: BoxDecoration(
                            image: DecorationImage(
                      image: AssetImage("assets/images/light-1.png"),
                    )))),
                Positioned(
                    right: 40,
                    top: 0,
                    width: 80,
                    height: 120,
                    child: Container(
                        decoration: BoxDecoration(
                            image: DecorationImage(
                      image: AssetImage("assets/images/clock.png"),
                    )))),
                Container(
                  child: Center(
                      child: Text(
                    "Login",
                    style: TextStyle(
                        color: Colors.white,
                        fontSize: 40,
                        fontWeight: FontWeight.bold),
                  )),
                )
              ]),
            ),
            Padding(
              padding: EdgeInsets.all(40),
              child: Container(
                decoration: BoxDecoration(
                    color: Colors.white,
                    borderRadius: BorderRadius.circular(10)),
                child: Column(children: [
                  Container(
                    padding: EdgeInsets.all(8),
                    decoration: BoxDecoration(
                        border: Border(bottom: BorderSide(color: Colors.grey))),
                    child: TextField(
                      controller: _usernameController,
                      decoration: InputDecoration(
                          border: InputBorder.none,
                          hintText: "Email or phone",
                          hintStyle: TextStyle(color: Colors.grey[400])),
                    ),
                  ),
                  Container(
                    padding: EdgeInsets.all(8),
                    child: TextField(
                      controller: _passwordController,
                      decoration: InputDecoration(
                          border: InputBorder.none,
                          hintText: "Pasword",
                          hintStyle: TextStyle(color: Colors.grey[400])),
                    ),
                  ),
                ]),
              ),
            ),
            SizedBox(
              height: 2,
            ),
            Container(
              height: 50,
              margin: EdgeInsets.fromLTRB(40, 0, 40, 0),
              decoration: BoxDecoration(
                borderRadius: BorderRadius.circular(10),
                gradient: LinearGradient(colors: [
                  Color.fromRGBO(143, 148, 251, 1),
                  Color.fromRGBO(143, 148, 251, .6)
                ]),
              ),
              child: InkWell(
                onTap: () async {
                  try {
                    Authorization.username = _usernameController.text;
                    Authorization.password = _passwordController.text;

                    await _userProvider.get();

                    Navigator.pushNamed(context, ProductListScreen.routeName);
                  } catch (e) {
                    showDialog(
                        context: context,
                        builder: (BuildContext context) => AlertDialog(
                              title: Text("Error"),
                              content: Text(e.toString()),
                              actions: [
                                TextButton(
                                  child: Text("Ok"),
                                  onPressed: () => Navigator.pop(context),
                                )
                              ],
                            ));
                  }
                },
                child: Center(child: Text("Login")),
              ),
            ),
            SizedBox(
              height: 40,
            ),
            Text("Forgot password?"),
            SizedBox(
              height: 40,
            ),
          ],
        ),
      ),
    );
  }
}
