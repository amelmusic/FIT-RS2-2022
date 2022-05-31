import 'package:eprodajamobile/providers/product_provider.dart';
import 'package:eprodajamobile/screens/products/product_list_screen.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

void main() => runApp(MultiProvider(
  providers: [
    ChangeNotifierProvider(create: (_) => ProductProvider()),
  ],
  child: MaterialApp(
      debugShowCheckedModeBanner: true,
      home: HomePage(),
      onGenerateRoute: (settings) {
        if (settings.name == ProductListScreen.routeName) {
          return MaterialPageRoute(builder: ((context) => ProductListScreen()));
        }
      },
    ),
));

class HomePage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
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
                  child: Text("Login", style: TextStyle(color: Colors.white, fontSize: 40, fontWeight: FontWeight.bold),)
                  ),
              )
            ]),
          ),
          Padding(
            padding: EdgeInsets.all(40),
            child: Container(
              decoration: BoxDecoration(
                color: Colors.white,
                borderRadius: BorderRadius.circular(10)
              ),
              child: Column(
              children: [
                Container(
                  padding: EdgeInsets.all(8),
                  decoration: BoxDecoration(
                    border: Border(bottom: BorderSide(color: Colors.grey))
                  ),
                  child: TextField(
                          decoration: InputDecoration(border: InputBorder.none, hintText: "Email or phone", hintStyle: TextStyle(color: Colors.grey[400])),
                  ),
                ),
                Container(
                  padding: EdgeInsets.all(8),
                  child: TextField(
                          decoration: InputDecoration(border: InputBorder.none, hintText: "Pasword", hintStyle: TextStyle(color: Colors.grey[400])),
                  ),
                ),

                
              ]),
            ),
          ),
          SizedBox(height: 2,),
          Container(
                  height: 50,
                  margin: EdgeInsets.fromLTRB(40, 0, 40, 0),
                  decoration: BoxDecoration(
                    borderRadius: BorderRadius.circular(10),
                    gradient: LinearGradient(
                      colors: [Color.fromRGBO(143, 148, 251, 1), Color.fromRGBO(143, 148, 251, .6)]
                    ),
                    
                  ),
                  child: InkWell(
                    onTap: () {
                      Navigator.pushNamed(context, ProductListScreen.routeName);
                    },
                    child: Center(child: Text("Login")),
                  ),
                ),
          SizedBox(height: 40,),
          Text("Forgot password?"),
          SizedBox(height: 40,),
        ],
      ),
      ),
    );
  }
}
