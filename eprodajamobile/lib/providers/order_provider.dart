import 'package:eprodajamobile/providers/base_provider.dart';

import '../model/order.dart';

class OrderProvider extends BaseProvider<Order> {
  OrderProvider() : super("Narudzbe");

  @override
  fromJson(data) {
    // TODO: implement fromJson
    return Order();
  }
}