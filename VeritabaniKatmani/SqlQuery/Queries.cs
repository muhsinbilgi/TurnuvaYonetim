using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeritabaniKatmani.SqlQuery
{
    public static class Queries
    {

        public static class Kullanicilar
        {
            public static string Insert => @"INSERT INTO `kullanicilar`(`AdiSoyadi`, `KullaniciAdi`, `Parola`, `Rol`,`TakimId`,`SeciliTurnuva`,`Resim`) 
                                                                 VALUES(@AdiSoyadi,@KullaniciAdi,@Parola,@Rol,@TakimId,@SeciliTurnuva, @Resim)";
            public static string Update => @"update `kullanicilar` set
                                         `AdiSoyadi` = @AdiSoyadi,
                                         `KullaniciAdi` = @KullaniciAdi,
                                         `Parola` = @Parola,
                                         `Rol` = @Rol,
                                         `SonGirisZamani` = @SonGirisZamani,
                                         `TakimId` = @TakimId,
                                         `SeciliTurnuva` = @SeciliTurnuva,
                                          `Resim` = @Resim
                                          where Id = @Id";

            public static string SecTurUpdate => @"update `kullanicilar` set
                                         `SeciliTurnuva` = @SeciliTurnuva
                                          where Id = @Id";

            public static string Delete => "delete from kullanicilar where Id = @Id";
            public static string GetAll => @"select * from kullanicilar";
            public static string GetbyId => "select * from kullanicilar where Id = @Id";

            public static string GetbyMaxId => "select Max(Id) as MaxId from kullanicilar";
            public static string GetbyName => @"select
                                                k.*,
                                                r.RolAciklama
                                                from kullanicilar k
                                                inner join Rol r on r.RolAdi = k.Rol
                                                where k.KullaniciAdi = @KullaniciAdi";

            public static string GetbyYon => @"select
                                                k.*,
                                                r.RolAciklama
                                                from kullanicilar k
                                                inner join Rol r on r.RolAdi = k.Rol
                                                where k.Rol = @Rol";
            public static string GetbyY => @"select
                                                k.*,
                                                r.RolAciklama
                                                from kullanicilar k
                                                inner join kullaniciturnuva t on t.KullaniciId = k.Id
                                                inner join Rol r on r.RolAdi = k.Rol
                                                where t.TurnuvaId = @TurnuvaId";
      

        }

        public static class Statu
        {
            public static string Insert => @"INSERT INTO `statu`(`Adi`) 
                                                                 VALUES(@Adi)";
            public static string Update => @"update `statu` set
                                         `Adi` = @Adi
                                          where Id = @Id";
            public static string Delete => "delete from statu where Id = @Id";
            public static string GetAll => @"select * from statu";
            public static string GetbyId => "select * from statu where Id = @Id";
        }

        public static class EvrakTuru
        {
            public static string Insert => @"INSERT INTO `evrakturu`(`Adi`) 
                                                                 VALUES(@Adi)";
            public static string Update => @"update `evrakturu` set
                                         `Adi` = @Adi
                                          where Id = @Id";
            public static string Delete => "delete from evrakturu where Id = @Id";
            public static string GetAll => @"select * from evrakturu";
            public static string GetbyId => "select * from evrakturu where Id = @Id";
        }

        public static class Turnuva
        {
            public static string Insert => @"INSERT INTO `turnuva`(`Adi`,`KategoriId`,`YoneticiKullaniciId`,`Logo`) 
                                                                 VALUES(@Adi,@KategoriId,@YoneticiKullaniciId,@Logo)";
            public static string Update => @"update `turnuva` set
                                         `Adi` = @Adi,
                                         `KategoriId` = @KategoriId,
                                         `YoneticiKullaniciId` = @YoneticiKullaniciId,
                                         `Logo` = @Logo
                                          where Id = @Id";
            public static string Delete => "delete from turnuva where Id = @Id";
            public static string GetAll => @"select
                                             t.*,
                                             k.Adi as KategoriAdi,
                                             u.AdiSoyadi as YoneticiAdi
                                             from turnuva t
                                             inner join kategori k on k.Id = t.KategoriId
                                             inner join kullanicilar u on u.Id = t.YoneticiKullaniciId";
            public static string GetbyId => "select * from turnuva where Id = @Id";
            public static string GetbyUser => "select * from turnuva where YoneticiKullaniciId = @Id";

            public static string GetbyTur => @"select t.id,t.Adi from turnuva t
                                               inner join kullaniciturnuva k on k.TurnuvaId = t.Id
                                               where k.KullaniciId = @Id";
        }                                                                        

        public static class Takimlar
        {
            public static string Insert => @"INSERT INTO `takimlar`(`Adi`, `KategoriId`, `Logo`, `Konum` ,`TurnuvaId` ) 
                                                                 VALUES(@Adi,@KategoriId,@Logo,@Konum,@TurnuvaId)";
            public static string Update => @"update `takimlar` set
                                          `Adi` = @Adi,
                                          `KategoriId` = @KategoriId,
                                          `Logo` = @Logo,
                                          `Konum` = @Konum,
                                          `TurnuvaId` = @TurnuvaId
                                          where Id = @Id";
            public static string Delete => "delete from takimlar where Id = @Id";
            public static string GetAll => @"select
                                             t.*,
                                             k.Adi as KategoriAdi
                                             from takimlar t 
                                             inner join kategori k on k.Id = t.KategoriId
                                             ";
            public static string GetbyId => @"select
                                             t.*,
                                             k.Adi as KategoriAdi
                                             from takimlar t
                                             inner join kategori k on k.Id = t.KategoriId 
                                             where t.Id = @Id";

            /* Yönetici için : */
            public static string GetbyY => "select * from takimlar t where t.TurnuvaId = @TurnuvaId";

            /* Takım Sorumlusu için : */
            public static string GetbyT => "select * from takimlar t where t.Id = @Id";
        }


        public static class Kategori
        {
            public static string Insert => @"INSERT INTO `kategori`(`Adi`) 
                                                                 VALUES(@Adi)";
            public static string Update => @"update `kategori` set
                                         `Adi` = @Adi
                                          where Id = @Id";
            public static string Delete => "delete from kategori where Id = @Id";
            public static string GetAll => @"select * from kategori";
            public static string GetbyId => "select * from kategori where Id = @Id";
        }
        public static class Sporcular
        {
            public static string Insert => @"INSERT INTO `sporcular`(`Adi`, `Soyadi`, `DogumTarihi`, `DogumYeri`, `Telefon`, `Email`, `Statu`, `Resim`, `KullaniciId`, `LisansNo`, `Mevki`, `TakimId`, `TurnuvaId`) VALUES 
                                     (@Adi, @Soyadi, @DogumTarihi, @DogumYeri, @Telefon, @Email, @Statu, @Resim, @KullaniciId, @LisansNo, @Mevki, @TakimId, @TurnuvaId)";

            public static string Update => @"UPDATE `sporcular` SET 
                                            `Adi` = @Adi, 
                                            `Soyadi` = @Soyadi, 
                                            `DogumTarihi` = @DogumTarihi, 
                                            `DogumYeri` = @DogumYeri, 
                                            `Telefon` = @Telefon, 
                                            `Email` = @Email, 
                                            `Statu` = @Statu, 
                                            `Resim` = @Resim, 
                                            `LisansNo` = @LisansNo, 
                                            `Mevki` = @Mevki, 
                                            `TakimId` = @TakimId
                                            WHERE `Id` = @Id;";
            public static string Delete => "delete from sporcular where Id = @Id";
            public static string Onay => @"update sporcular set 
                                           onay = @onay
                                           where Id = @Id";

            public static string GetAll => @"select
s.*,
t.Adi as TakımAdi,
st.Adi as StatuAdi
from sporcular s
inner join takimlar t on t.Id = s.TakimId
inner join statu st on st.Id = s.Statu";
            public static string GetbyId => @"select 
 s.*,
 t.Adi as TakımAdi,
 st.Adi as StatuAdi
 from sporcular s
 inner join takimlar t on t.Id = s.TakimId
 inner join statu st on st.Id = s.Statu
 where s.Id = @Id";

            public static string GetSearch => @"select 
 s.*,
 t.Adi as TakımAdi,
 st.Adi as StatuAdi
 from sporcular s
 inner join takimlar t on t.Id = s.TakimId
 inner join statu st on st.Id = s.Statu
 where t.Adi like @TakimAdi or s.Adi like @SporcuAdi";


            /* Yönetici için : */
            public static string GetbyY => "select * from sporcular s where s.TurnuvaId = @TurnuvaId";

            /* Takım Sorumlusu için : */
            public static string GetbyT => "select * from sporcular s where s.TakimId= @TakimId";

            /* Sporcu için : */
            public static string GetbyS => "select * from sporcular s where s.KullaniciId= @KullaniciId";

        }


        public static class Gorevliler
        {
            public static string Insert => @"INSERT INTO `gorevliler`(`Adi`, `Soyadi`, `GorevTuru`, `Resim` ,`TurnuvaId` ) 
                                                                 VALUES(@Adi,@Soyadi,@GorevTuru,@Resim,@TurnuvaId)";
            public static string Update => @"update `gorevliler` set
                                          `Adi` = @Adi,
                                          `Soyadi` = @Soyadi,
                                          `GorevTuru` = @GorevTuru,
                                          `Resim` = @Resim,
                                          `TurnuvaId` = @TurnuvaId
                                          where Id = @Id";
            public static string Delete => "delete from gorevliler where Id = @Id";
            public static string GetAll => @"select
                                             t.*,
                                             g.Adi as GorevAdi
                                             from gorevliler t 
                                             inner join gorevturu g on g.Id = t.GorevTuru
                                             ";
            public static string GetbyId => @"select
                                             t.*,
                                             g.Adi as GorevAdi
                                             from gorevliler t 
                                             inner join gorevturu g on g.Id = t.GorevTuru
                                             where t.Id = @Id";
            /* Yönetici için : */
            public static string GetbyY => "select * from gorevliler s where s.TurnuvaId = @TurnuvaId";


        }

        public static class GorevTuru
        {
            public static string Insert => @"INSERT INTO `gorevturu`(`Adi`) 
                                                                 VALUES(@Adi)";
            public static string Update => @"update `gorevturu` set
                                         `Adi` = @Adi
                                          where Id = @Id";
            public static string Delete => "delete from gorevturu where Id = @Id";
            public static string GetAll => @"select * from gorevturu";
            public static string GetbyId => "select * from gorevturu where Id = @Id";
        }

        public static class Maclar
        {
            public static string Insert => @"INSERT INTO `maclar`(`Tarih`,`Saat`,`BirinciTakimId`,`IkinciTakimId`,`Bay`,`Hafta`,`TurnuvaId`) 
                                                                 VALUES(@Tarih,@Saat,@BirinciTakimId,@IkinciTakimId,@Bay,@Hafta,@TurnuvaId)";
            public static string Update => @"update `maclar` set
                                         `Tarih` = @Tarih,
                                          `Saat`= @Saat,
                                          `BirinciTakimId`= @BirinciTakimId,
                                          `IkinciTakimId`= @IkinciTakimId,
                                          `Bay`= @Bay,
                                          `Hafta`= @Hafta,
                                          `TurnuvaId` = @TurnuvaId
                                          where Id = @Id";
            public static string Delete => "delete from maclar where Id = @Id";
            public static string GetAll => @"select 
                                             m.*,
                                             t1.Adi as BirinciTakimAdi,
                                             t2.Adi as IkinciTakimAdi
                                             from maclar m
                                             inner join takimlar t1 on t1.Id = m.BirinciTakimId
                                             inner join takimlar t2 on t2.Id = m.IkinciTakimId";

         
            public static string GetbyId => "select * from maclar where Id = @Id";

            public static string GetbyMax => "select max(hafta) as MaxHafta from maclar where TurnuvaId = @TurnuvaId";
        }



        public static class Evrak
        {
            public static string Insert => @"INSERT INTO `evrak`(`SporcuId`,`EvrakTuru`,`EvrakAdi`) 
                                                                 VALUES(@SporcuId,@EvrakTuru,@EvrakAdi)";
            public static string Update => @"update `evrak` set
                                         `SporcuId` = @SporcuId,
                                          `EvrakTuru`= @EvrakTuru,
                                          `EvrakAdi`= @EvrakAdi
                                           where Id = @Id";
            public static string Delete => "delete from evrak where Id = @Id";
            public static string GetAll => @"select * from evrak";
            public static string GetbyId => "select * from evrak where Id = @Id";
            public static string GetbyCount => "select count(*) as Sayi from evrak where SporcuId = @Id";
            public static string GetbySporcuId => @"select
                                                    e.*,
                                                    t.Adi as EvrakTuruAdi
                                                    from evrak e
                                                    inner join EvrakTuru t on t.Id = e.EvrakTuru
                                                    where SporcuId = @Id";


        }

        public static class Rol
        {
 
            public static string GetAll => @"select * from rol where Yetki = 1";

        }

        public static class Gruplar
        {
            public static string Insert => @"INSERT INTO `gruplar`(`GrupId`, `TakimId`, `TurnuvaId`) 
                                                                 VALUES(@GrupId,@TakimId,@TurnuvaId)";


            public static string Delete => "delete from gruplar where Id = @Id";
            public static string GetAll => @"select
                                           t.Adi as TakimAdi,
                                           g.*
                                           from gruplar g
                                           inner join takimlar t on t.id = g.TakimId
                                           where g.TurnuvaId = @Id";
            public static string GetbyId => "select * from gruplar where Id = @Id";

            public static string GetMaxGrup => "select COUNT(*) as MaxGrup from (select * from gruplar group by GrupId) as grp where TurnuvaId = @TurnuvaId";

         
        }

        public static class GrupAdlari
        {
            public static string GetbyId => "select GrupId from gruplar where TurnuvaId = @TurnuvaId group by GrupId";

        }


        public static class MacHaftalari
        {
            public static string GetbyId => "select Hafta from maclar where TurnuvaId = @TurnuvaId group by Hafta";

        }



        public static class KullaniciTurnuva
        {
            public static string Insert => @"INSERT INTO `kullaniciturnuva`(`TurnuvaId`, `KullaniciId`) 
                                                                 VALUES(@TurnuvaId,@KullaniciId)";
            public static string Update => @"update `kullaniciturnuva` set
                                         `TurnuvaId` = @TurnuvaId,
                                         `KullaniciId` = @KullaniciId
                                          where KullaniciId = @KullaniciId";


            public static string Delete => "delete from kullaniciturnuva where Id = @Id";
            public static string GetAll => @"select * from kullaniciturnuva";
            public static string GetbyId => "select * from kullaniciturnuva where Id = @Id";

       


        }

        public static class MacDetay
        {
            public static string Insert => @"INSERT INTO `MacDetay`(`MacId`,`TakimId`,`SporcuId`,`DetayId`,`DetayDakika`) 
                                                                 VALUES(@MacId,@TakimId,@SporcuId,@DetayId,@DetayDakika,)";
            public static string Update => @"update `MacDetay` set
                                         `MacId` = @MacId
                                         `TakimId` = @TakimId
                                         `SporcuId` = @SporcuId
                                         `DetayId` = @DetayId
                                         `DetayDakika` = @DetayDakika
                                          where Id = @Id";
            public static string Delete => "delete from MacDetay where Id = @Id";
            public static string GetAll => @"select * from MacDetay";

            public static string GetbyId => @"select 
t1.Adi as BirinciTakimAdi,
t2.Adi as IkinciTakimAdi,
(select COUNT(*) from macdetay md1 where md1.TakimId = t1.Id and md1.DetayId = 1) as BirinciTakimSkor,
(select COUNT(*) from macdetay md1 where md1.TakimId = t2.Id and md1.DetayId = 1) as IkinciTakimSkor,
t1.Logo as BirinciTakimLogo,
t2.Logo as IkinciTakimLogo,
m.Hafta as Hafta
from Maclar m
inner join takimlar t1 on t1.Id = m.BirinciTakimId
inner join takimlar t2 on t2.Id = m.IkinciTakimId
inner join macdetay md on md.MacId = m.Id
inner join sporcular s on s.Id = md.SporcuId
inner join detay d on d.Id = md.DetayId
 where m.Id = @Id";


        }






















    }
}
