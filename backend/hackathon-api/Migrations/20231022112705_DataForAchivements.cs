using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hackathon_api.Migrations
{
    /// <inheritdoc />
    public partial class DataForAchivements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			var createProcSql = @"
            INSERT INTO Achivements
		VALUES ('FirstLogin',20,1,'FirstLogin'),
			   ('Two Days Login',40,2,'TwoDaysLogin'),
			   ('Verification',40,1,'Verification');

		INSERT INTO Achivements 
		VALUES ('Deposit',20,1,'Deposit'),
			   ('Deposit',40,80,'Deposit'),
			   ('Deposit',60,400,'Deposit'),
			   ('Deposit',80,600,'Deposit');

		INSERT INTO Achivements 
		VALUES ('Withdraw',20,1,'Withdraw'),
			   ('Withdraw',40,80,'Withdraw'),
			   ('Withdraw',60,400,'Withdraw'),
			   ('Withdraw',80,600,'Withdraw');


		INSERT INTO Achivements 
		VALUES ('PrematchPlay',20,1,'prematch'),
			   ('PrematchPlay',40,5,'prematch'),
			   ('PrematchPlay',60,10,'prematch'),
			   ('PrematchPlay',80,15,'prematch');

		INSERT INTO Achivements 
		VALUES ('LivePlay',20,1,'live'),
			   ('LivePlay',40,5,'live'),
			   ('LivePlay',60,10,'live'),
			   ('LivePlay',80,15,'live');
   
		INSERT INTO Achivements 
		VALUES ('BingoPlay',20,1,'bingo'),
			   ('BingoPlay',40,5,'bingo'),
			   ('BingoPlay',60,10,'bingo'),
			   ('BingoPlay',80,15,'bingo');

	     
		INSERT INTO Achivements 
		VALUES ('CasinoPlay',20,1,'casino'),
			   ('CasinoPlay',40,5,'casino'),
			   ('CasinoPlay',60,10,'casino'),
			   ('CasinoPlay',80,15,'casino');
   
	     
		INSERT INTO Achivements 
		VALUES ('VGPlay',20,1,'vg'),
			   ('VGPlay',40,5,'vg'),
			   ('VGPlay',60,10,'vg'),
			   ('VGPlay',80,15,'vg');

 

		INSERT INTO Achivements 
		VALUES ('PrematchBet',20,5,'prematch'),
			   ('PrematchBet',40,10,'prematch'),
			   ('PrematchBet',60,20,'prematch'),
			   ('PrematchBet',80,30,'prematch');

		INSERT INTO Achivements 
		VALUES ('LiveBet',20,5,'live'),
			   ('LiveBet',40,10,'live'),
			   ('LiveBet',60,20,'live'),
			   ('LiveBet',80,30,'live');
   
		INSERT INTO Achivements 
		VALUES ('BingoBet',20,5,'bingo'),
			   ('BingoBet',40,10,'bingo'),
			   ('BingoBet',60,20,'bingo'),
			   ('BingoBet',80,30,'bingo');

	     
		INSERT INTO Achivements 
		VALUES ('CasinoBet',20,5,'casino'),
			   ('CasinoBet',40,10,'casino'),
			   ('CasinoBet',60,20,'casino'),
			   ('CasinoBet',80,30,'casino');
   
		select * from Achivements
	     
		INSERT INTO Achivements 
		VALUES ('VGBet',20,5,'vg'),
			   ('VGBet',40,10,'vg'),
			   ('VGBet',60,20,'vg'),
			   ('VGBet',80,30,'vg');


		INSERT INTO Achivements 
		VALUES ('PrematchWin',20,1,'prematch'),
			   ('PrematchWin',40,5,'prematch'),
			   ('PrematchWin',60,10,'prematch'),
			   ('PrematchWin',80,15,'prematch');

		INSERT INTO Achivements 
		VALUES ('LiveWin',20,1,'live'),
			   ('LiveWin',40,5,'live'),
			   ('LiveWin',60,10,'live'),
			   ('LiveWin',80,15,'live');
   
		INSERT INTO Achivements 
		VALUES ('BingoWin',20,1,'bingo'),
			   ('BingoWin',40,5,'bingo'),
			   ('BingoWin',60,10,'bingo'),
			   ('BingoWin',80,15,'bingo');

	     
		INSERT INTO Achivements 
		VALUES ('CasinoWin',20,1,'casino'),
			   ('CasinoWin',40,5,'casino'),
			   ('CasinoWin',60,10,'casino'),
			   ('CasinoWin',80,15,'casino');

	     
		INSERT INTO Achivements 
		VALUES ('VGWin',20,1,'vg'),
			   ('VGWin',40,5,'vg'),
			   ('VGWin',60,10,'vg'),
			   ('VGWin',80,15,'vg');


		INSERT INTO Achivements 
		VALUES ('PrematchFree',20,1,'prematch'),
			   ('PrematchFree',40,5,'prematch'),
			   ('PrematchFree',60,10,'prematch'),
			   ('PrematchFree',80,15,'prematch');

		select * from Achivements

		INSERT INTO Achivements 
		VALUES ('LiveFree',20,1,'live'),
			   ('LiveFree',40,5,'live'),
			   ('LiveFree',60,10,'live'),
			   ('LiveFree',80,15,'live');
   
		INSERT INTO Achivements 
		VALUES ('BingoFree',20,1,'bingo'),
			   ('BingoFree',40,5,'bingo'),
			   ('BingoFree',60,10,'bingo'),
			   ('BingoFree',80,15,'bingo');

	     
		INSERT INTO Achivements 
		VALUES ('CasinoFree',20,1,'casino'),
			   ('CasinoFree',40,5,'casino'),
			   ('CasinoFree',60,10,'casino'),
			   ('CasinoFree',80,15,'casino');

	     
		INSERT INTO Achivements 
		VALUES ('VGFree',20,1,'vg'),
			   ('VGFree',40,5,'vg'),
			   ('VGFree',60,10,'vg'),
			   ('VGFree',80,15,'vg');
            ";
			migrationBuilder.Sql(createProcSql);
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
			var dropProcSql = "DELETE FROM Achivements";
			migrationBuilder.Sql(dropProcSql);
		}
    }
}
