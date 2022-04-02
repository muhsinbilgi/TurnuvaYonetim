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
                                         `TakimId` = @TakimId,
                                         `SeciliTurnuva` = @SeciliTurnuva,
                                          `Resim` = @Resim
                                          where Id = @Id";

            public static string ProfilUpdate => @"update `kullanicilar` set
                                                  `AdiSoyadi` = @AdiSoyadi,
                                                  `KullaniciAdi` = @KullaniciAdi,
                                                  `Parola` = @Parola,
                                                  `Resim` = @Resim
                                                   where Id = @Id";

            public static string SonGirisUpdate => @"update `kullanicilar` set
                                                  `SonGirisZamani` = @SonGirisZamani
                                                   where Id = @Id";



            public static string SecTurUpdate => @"update `kullanicilar` set
                                         `SeciliTurnuva` = @SeciliTurnuva
                                          where Id = @Id";

            public static string Delete => "delete from kullanicilar where Id = @Id";
            public static string GetAll => @"select * from kullanicilar";
            public static string GetbyId => @"select
                                                k.*,
                                                r.RolAciklama
                                                from kullanicilar k
                                                inner join Rol r on r.RolAdi = k.Rol
                                                where k.Id = @Id";

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
        public static class Detay
        {
            public static string Insert => @"INSERT INTO `Detay`(`Adi`,`KategoriId`) 
                                                                 VALUES(@Adi,@KategoriId)";
            public static string Update => @"update `Detay` set
                                         `Adi` = @Adi,
                                        `KategoriId` = @KategoriId
                                          where Id = @Id";
            public static string Delete => "delete from Detay where Id = @Id";
            public static string GetAll => @"select * from Detay";
            public static string GetbyId => "select * from Detay where Id = @Id";
        }

        public static class Hafta
        {
            public static string Insert => @"INSERT INTO `Hafta`(`Adi`,) 
                                                                 VALUES(@Adi)";
            public static string Update => @"update `Hafta` set
                                         `Adi` = @Adi
                                          where Id = @Id";
            public static string Delete => "delete from Hafta where Id = @Id";
            public static string GetAll => @"select * from Hafta";
            public static string GetbyId => "select * from Hafta where Id = @Id";

            public static string GetbyAd => "select * from Hafta where Adi = @Adi";
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
            public static string GetByMaxId => "select max(Id) as Id from turnuva";

            public static string GetByTakimSayisi => @"select COUNT(*) as TakimSayisi from turnuva t 
                                                       inner join takimlar tk on tk.TurnuvaId = t.Id
                                                       where t.Id = @Id";

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

            /*Bir takımın grubundaki diğer takımları getirmek için */
            public static string GetbyGT => @"select t.* from takimlar t
                                              left join gruplar g on g.TakimId = t.Id
                                              where g.GrupId in (select g.GrupId from gruplar g where g.TakimId =@TakimId) and g.TakimId != @TakimId and g.TurnuvaId = @TurnuvaId
                                              union 
                                              select 
                                              0 as Id,
                                              'Bay' as Adi,
                                              1 as kategoriId,
                                              null as Logo,
                                              null as Konum,
                                              null as TurnuvaId";

            /* Grupa dahil olmayan takımları getirmek için */
            public static string GetbyGrp => @"select t.* from takimlar t 
                                             left join gruplar g on g.TakimId = t.Id and t.TurnuvaId = g.TurnuvaId
                                             where g.GrupId is null and t.TurnuvaId = @TurnuvaId";
          

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
            public static string GetbyY => @"select t.Adi as TakimAdi,s.* from sporcular s 
                                             left join takimlar t on t.Id = s.TakimId
                                            where s.TurnuvaId = @TurnuvaId";

            /* Takım Sorumlusu için : */
            public static string GetbyT => @"select t.Adi as TakimAdi,s.* from sporcular s 
                                             left join takimlar t on t.Id = s.TakimId
                                             where s.TakimId= @TakimId";

            /* Sporcu için : */
            public static string GetbyS => @"select t.Adi as TakimAdi,s.* from sporcular s 
                                             left join takimlar t on t.Id = s.TakimId
                                             where s.KullaniciId= @KullaniciId";

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
            public static string Insert => @"INSERT INTO `maclar`(`TarihSaat`,`BirinciTakimId`,`IkinciTakimId`,`Bay`,`Hafta`,`TurnuvaId`) 
                                                                 VALUES(@TarihSaat,@BirinciTakimId,@IkinciTakimId,@Bay,@Hafta,@TurnuvaId)";
            public static string Update => @"update `maclar` set
                                         `Tarih` = @Tarih,
                                          `Saat`= @Saat,
                                          `BirinciTakimId`= @BirinciTakimId,
                                          `IkinciTakimId`= @IkinciTakimId,
                                          `Bay`= @Bay,
                                          `Hafta`= @Hafta,
                                          `TurnuvaId` = @TurnuvaId,
                                          `BirinciTakimSkor` = @BirinciTakimSkor,
                                          `IkinciTakimSkor` = @IkinciTakimSkor
                                          where Id = @Id";

            public static string SkorUpdate => @"update `maclar` set
                                         `BirinciTakimSkor` = @BirinciTakimSkor,
                                          `IkinciTakimSkor` = @IkinciTakimSkor
                                          where Id = @Id";
            public static string Delete => "delete from maclar where Id = @Id";
            public static string GetAll => @"select 
                                             m.Id,
                                             m.TarihSaat,
                                             m.BirinciTakimId,
                                             m.IkinciTakimId,
                                             m.Bay,
                                             h.Adi as Hafta,
                                             m.TurnuvaId,
                                             m.BirinciTakimSkor,
                                             m.IkinciTakimSkor,
                                              t1.Adi as BirinciTakimAdi,
                                              t2.Adi as IkinciTakimAdi
                                              from maclar m
                                              left join Hafta h on h.Id = m.Hafta
                                              left join takimlar t1 on t1.Id = m.BirinciTakimId
                                              left join takimlar t2 on t2.Id = m.IkinciTakimId
                                              where m.TurnuvaId = @TurnuvaId
                                             order by t2.Adi DESC";
                                               
                          

         
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


            public static string Delete => "delete from gruplar where GrupId = @GrupId";


            public static string Update => @"update `gruplar` set
                                         `OynadigiMac` = @OynadigiMac,
                                          `Galibiyet`= @Galibiyet,
                                          `Maglubiyet`= @Maglubiyet,
                                          `Beraberlik`= @Beraberlik,
                                          `AttigiGol`= @AttigiGol,
                                          `YedigiGol`= @YedigiGol,
                                          `Puan`= @Puan
                                           where Id = @Id";

            public static string GetAll => @"select
                                           t.Adi as TakimAdi,
                                           g.*
                                           from gruplar g
                                           inner join takimlar t on t.id = g.TakimId
                                           where g.TurnuvaId = @Id
                                           order by g.puan desc";
            public static string GetbyId => "select * from gruplar where Id = @Id";

            public static string GetMaxGrup => "select COUNT(*) as MaxGrup from (select * from gruplar group by GrupId) as grp where TurnuvaId = @TurnuvaId";

            public static string GetPuanDurumu => @"select
                                                  gr.Id,
                                                  gr.GrupId,
                                                  tk.Id as TakimId,
                                                  gr.TurnuvaId,
                                                  (select COUNT(*) from maclar m1 where m1.BirinciTakimId = tk.Id and m1.BirinciTakimSkor is not null) + 
                                                  (select COUNT(*) from maclar m2 where m2.IkinciTakimId = tk.Id and m2.IkinciTakimSkor is not null) as OynadigiMac,
                                                  (select COALESCE(sum(if(m1.BirinciTakimSkor > m1.IkinciTakimSkor,1,0)),0) from maclar m1 where m1.BirinciTakimId = tk.Id) +
                                                  (select COALESCE(sum(if(m2.IkinciTakimSkor > m2.BirinciTakimSkor,1,0)),0) from maclar m2 where m2.IkinciTakimId = tk.Id) as Galibiyet,
                                                  (select COALESCE(sum(if(m1.BirinciTakimSkor < m1.IkinciTakimSkor,1,0)),0) from maclar m1 where m1.BirinciTakimId = tk.Id) +
                                                  (select COALESCE(sum(if(m2.IkinciTakimSkor < m2.BirinciTakimSkor,1,0)),0) from maclar m2 where m2.IkinciTakimId = tk.Id) as Maglubiyet,
                                                  (select COALESCE(sum(if(m1.BirinciTakimSkor = m1.IkinciTakimSkor,1,0)),0) from maclar m1 where m1.BirinciTakimId = tk.Id) +
                                                  (select COALESCE(sum(if(m2.IkinciTakimSkor = m2.BirinciTakimSkor,1,0)),0) from maclar m2 where m2.IkinciTakimId = tk.Id) as Beraberlik,
                                                  (select COALESCE(sum(m1.BirinciTakimSkor),0) from maclar m1 where m1.BirinciTakimId = tk.Id) +
                                                  (select COALESCE(sum(m2.IkinciTakimSkor),0) from maclar m2 where m2.IkinciTakimId = tk.Id) as AttigiGol,
                                                  (select COALESCE(sum(m1.IkinciTakimSkor),0) from maclar m1 where m1.BirinciTakimId = tk.Id) +
                                                  (select COALESCE(sum(m2.BirinciTakimSkor),0) from maclar m2 where m2.IkinciTakimId = tk.Id) as YedigiGol,
                                                  COALESCE((select 
                                                  SUM(case  when m1.BirinciTakimSkor > m1.IkinciTakimSkor then 3 when m1.BirinciTakimSkor = m1.IkinciTakimSkor then 1 when m1.BirinciTakimSkor < m1.IkinciTakimSkor then 0 else 0 end)
                                                  from maclar m1 where m1.BirinciTakimId = tk.Id),0) +
                                                  COALESCE((select 
                                                  SUM(case  when m2.IkinciTakimSkor > m2.BirinciTakimSkor then 3 when m2.IkinciTakimSkor = m2.BirinciTakimSkor then 1 when m2.IkinciTakimSkor < m2.BirinciTakimSkor then 0 else 0 end)
                                                  from maclar m2 where m2.IkinciTakimId = tk.Id),0) as Puan,
                                                  tk.Adi as TakimAdi
                                                  from takimlar tk
                                                  left join gruplar gr on gr.TakimId = tk.Id
                                                  where tk.TurnuvaId = @TurnuvaId";

            public static string GetByGrupListesi => "select * from gruplar where TurnuvaId =  @TurnuvaId";

        }

        public static class GrupAdlari
        {
            public static string GetbyId => "select GrupId from gruplar where TurnuvaId = @TurnuvaId group by GrupId";

        }


        public static class MacHaftalari
        {
            public static string GetbyId => @"select h.Adi as Hafta from maclar m
                                             left join Hafta h on h.id = m.Hafta
                                             where m.TurnuvaId = @TurnuvaId group by m.Hafta";

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
            public static string Insert => @"INSERT INTO `macdetay`(`MacId`,`TakimId`,`SporcuId`,`DetayId`,`DetayDakika`) 
                                                                 VALUES(@MacId,@TakimId,@SporcuId,@DetayId,@DetayDakika)";
            public static string Update => @"update `macdetay` set
                                         `MacId` = @MacId
                                         `TakimId` = @TakimId
                                         `SporcuId` = @SporcuId
                                         `DetayId` = @DetayId
                                         `DetayDakika` = @DetayDakika
                                          where Id = @Id";
            public static string Delete => "delete from macdetay where Id = @Id";
            public static string GetAll => @"select * from macdetay";

            public static string GetbyId => @"select 
                                             md.Id,
                                             m.Id as MacId,
                                             md.TakimId,
                                             t1.Adi as BirinciTakimAdi,
                                             t2.Adi as IkinciTakimAdi,
                                             t1.Id as BirinciTakimId,
                                             t2.Id as IkinciTakimId,
                                             md.SporcuId,
                                             concat(s.Adi,' ',s.Soyadi) as SporcuAdi,
                                             d.Adi as Detayadi,
                                             md.DetayId,
                                             md.DetayDakika,
                                             (select COUNT(*) from macdetay md1 where md1.MacId = m.Id and md1.TakimId = t1.Id and md1.DetayId = 1) as BirinciTakimSkor,
                                             (select COUNT(*) from macdetay md1 where md1.MacId = m.Id and md1.TakimId = t2.Id and md1.DetayId = 1) as IkinciTakimSkor,
                                             t1.Logo as BirinciTakimLogo,
                                             t2.Logo as IkinciTakimLogo,
                                             m.TarihSaat as MacTarihSaat,
                                             m.Hafta as Hafta
                                             from Maclar m
                                             inner join takimlar t1 on t1.Id = m.BirinciTakimId
                                             inner join takimlar t2 on t2.Id = m.IkinciTakimId
                                             left join macdetay md on md.MacId = m.Id
                                             left join sporcular s on s.Id = md.SporcuId
                                             left join detay d on d.Id = md.DetayId
                                              where m.Id = @Id
                                             order by md.DetayDakika asc";

            public static string GetbyDetayId => "select * from macdetay where  Id = @Id";

            public static string GetTkm => @"select 
m.BirinciTakimId as Id,
t1.Adi
from Maclar m
inner join Takimlar t1 on t1.Id = m.BirinciTakimId
where m.Id = @Id
union
select 
m.IkinciTakimId as Id,
t2.Adi
from Maclar m
inner join Takimlar t2 on t2.Id = m.IkinciTakimId
where m.Id = @Id";

        }

        public static class GenelBilgiler
        {
            public static string istatistikler => @"select
                                        (select COUNT(*) from sporcular s where s.TurnuvaId = trn.id) as SporcuSayisi,
                                        (select COUNT(*) from takimlar t where t.TurnuvaId = trn.id) as TakimSayisi,
                                        (select COUNT(*) from macdetay md inner join takimlar tk on tk.Id = md.TakimId where md.DetayId = 1 and tk.TurnuvaId = trn.id) as AtilanGol,
                                        (select COUNT(*) from macdetay md inner join takimlar tk on tk.Id = md.TakimId where md.DetayId = 2 and tk.TurnuvaId = trn.id) as SarikartSayisi,
                                        (select COUNT(*) from macdetay md inner join takimlar tk on tk.Id = md.TakimId where md.DetayId = 3 and tk.TurnuvaId = trn.id) as KirmizikartSayisi
                                        from turnuva trn
                                         where trn.Id = @Id";

            public static string golkralligi => @"select
                                         s.Resim,
                                         tk.Adi as TakimAdi,
                                         concat(s.Adi,' ',s.Soyadi) as AdiSoyadi,
                                         COUNT(*) as GolSayisi
                                         from macdetay md 
                                         left join sporcular s on s.id = md.SporcuId
                                         left join takimlar tk on tk.Id = s.TakimId
                                         where md.DetayId = 1 and s.TurnuvaId = @Id
                                         GROUP BY md.SporcuId,md.DetayId
                                         order by GolSayisi desc";
            public static string centilmenlik => @"select
                                         tk.Adi as TakimAdi,
                                         (SELECT COUNT(*) from macdetay md where md.TakimId = tk.Id and md.DetayId = 2) as SarikartSayisi,
                                         (SELECT COUNT(*) from macdetay md where md.TakimId = tk.Id and md.DetayId = 3) as KirmizikartSayisi
                                         from takimlar tk
                                         where tk.TurnuvaId = @Id
                                         ORDER BY (KirmizikartSayisi+SarikartSayisi) desc";

        }



        public static class Gunler
        {

            public static string GetAll => "select * from gunler";


        }

        public static class MacSablonu
        {

            public static string GetCount => "select count(*) as GrupMacSayisi from macsablon where GrupTakimSayisi = @Sayi";

            public static string GetAll => "select * from macsablon";
        }















    }

}

