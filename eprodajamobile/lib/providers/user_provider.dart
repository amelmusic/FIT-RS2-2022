import '../model/user.dart';
import 'base_provider.dart';

class UserProvider extends BaseProvider<User> {
  UserProvider() : super("Korisnici");

  @override
  User fromJson(data) {
    // TODO: implement fromJson
    return User();
  }
}
