select Leje.Id,Kunde.Navn as KundeNavn,Bil.Model as BilModel,Leje.Dato,Leje.AntalDage
                from Leje
                inner join Kunde on Leje.KundeId=Kunde.Id
                inner join Bil on Leje.BilId=Bil.Id;