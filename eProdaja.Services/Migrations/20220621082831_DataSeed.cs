using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eProdaja.Services.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "JediniceMjere",
                columns: new[] { "JedinicaMjereID", "Naziv" },
                values: new object[,]
                {
                    { 1, "kom" },
                    { 2, "kg" }
                });

            migrationBuilder.InsertData(
                table: "Korisnici",
                columns: new[] { "KorisnikID", "Email", "Ime", "KorisnickoIme", "LozinkaHash", "LozinkaSalt", "Prezime", "Telefon" },
                values: new object[,]
                {
                    { 1, "test@fit.ba", "Test", "test", "7p3l25Cnbg+2QxoQRElFJjIqHgA=", "H4pOSYtdeJgGsU/6HRTxqw==", "Test", null },
                    { 2, "admin@fit.ba", "Administrator", "admin", "JfJzsL3ngGWki+Dn67C+8WLy73I=", "7TUJfmgkkDvcY3PB/M4fhg==", "Administrator", null }
                });

            migrationBuilder.InsertData(
                table: "Uloge",
                columns: new[] { "UlogaID", "Naziv", "Opis" },
                values: new object[,]
                {
                    { 1, "Administrator", null },
                    { 2, "Menadžer", null }
                });

            migrationBuilder.InsertData(
                table: "VrsteProizvoda",
                columns: new[] { "VrstaID", "Naziv" },
                values: new object[,]
                {
                    { 1, "PC" },
                    { 2, "Laptop" },
                    { 3, "Monitor" }
                });

            migrationBuilder.InsertData(
                table: "KorisniciUloge",
                columns: new[] { "KorisnikUlogaID", "DatumIzmjene", "KorisnikID", "UlogaID" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 6, 21, 0, 0, 0, 0, DateTimeKind.Local), 1, 1 },
                    { 2, new DateTime(2022, 6, 21, 0, 0, 0, 0, DateTimeKind.Local), 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Proizvodi",
                columns: new[] { "ProizvodID", "Cijena", "JedinicaMjereID", "Naziv", "Sifra", "Slika", "SlikaThumb", "StateMachine", "Status", "VrstaID" },
                values: new object[,]
                {
                    { 1, 100m, 1, "Dell Inspiron 3477", "P001", null, null, "draft", true, 1 },
                    { 2, 120m, 1, "Dell Inspiron 5475", "P002", null, null, "draft", true, 1 },
                    { 3, 1201m, 1, "HP Pavilion 22-b001ny", "P003", null, null, "draft", true, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "JediniceMjere",
                keyColumn: "JedinicaMjereID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "KorisniciUloge",
                keyColumn: "KorisnikUlogaID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "KorisniciUloge",
                keyColumn: "KorisnikUlogaID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Proizvodi",
                keyColumn: "ProizvodID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Proizvodi",
                keyColumn: "ProizvodID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Proizvodi",
                keyColumn: "ProizvodID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Uloge",
                keyColumn: "UlogaID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VrsteProizvoda",
                keyColumn: "VrstaID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "JediniceMjere",
                keyColumn: "JedinicaMjereID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Uloge",
                keyColumn: "UlogaID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VrsteProizvoda",
                keyColumn: "VrstaID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VrsteProizvoda",
                keyColumn: "VrstaID",
                keyValue: 2);
        }
    }
}
