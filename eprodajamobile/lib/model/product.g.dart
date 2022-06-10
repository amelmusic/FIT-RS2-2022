// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'product.dart';

// **************************************************************************
// JsonSerializableGenerator
// **************************************************************************

Product _$ProductFromJson(Map<String, dynamic> json) => Product()
  ..proizvodId = json['proizvodId'] as int?
  ..naziv = json['naziv'] as String?
  ..cijena = json['cijena'] as double?
  ..slika = json['slika'] as String?;

Map<String, dynamic> _$ProductToJson(Product instance) => <String, dynamic>{
      'proizvodId': instance.proizvodId,
      'naziv': instance.naziv,
      'slika': instance.slika,
    };
