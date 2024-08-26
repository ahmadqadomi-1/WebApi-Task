use APITASK3;
GO
CREATE TABLE Rapper (
    RapperID int identity(1,1) primary key,
    RapperName varchar(225),
    RapperImage varchar(225)
);
INSERT INTO Rapper (RapperName, RapperImage)
VALUES 
('BigSam', 'BigSam.jpg'),
('emsallam', 'Emsallam.jpg'),
('Illiam', 'Illiam.jpg'),
('ShabJdeed', 'ShabJdeed.jpg'),
('TheSynaptik', 'Synop.jpg');


CREATE TABLE Track (
    TrackID int identity(1,1) primary key,
    TrackName varchar(225), 
    Description varchar(225),
    duration varchar(225),
    RapperID int,
    TrackImage varchar(MAX),
    FOREIGN KEY (RapperID) REFERENCES Rapper(RapperID)
);
INSERT INTO Track (TrackName, Description, duration, RapperID, TrackImage)
VALUES 
('3la7ali', 'Hard Track', '3:47', 1, '3la7ali.jpg'),
('8ooli', 'Best Album', '3:02', 1, '8ooli.jpg'),
('LawMarahBas', 'Best Tarck', '3:33', 1, 'LawMarahBas.jpg'),
('Shammir', 'Hard Old Sam', '6:01', 1, 'Shammir.jpg'),
('ThankYou', 'Best FT', '3:24', 1, 'ThankYou.jpg'),
('Tuxedo', 'Last Old Sam', '2:48', 1, 'Tuxedo.jpg'),

('7ootBMasba7', 'FirstTrackListen', '5:11', 2, '7ootBMasba7.jpg'),
('BedayatAlNehaya', 'For History', '2:58', 2, 'BedayatAlNehaya.jpg'),
('DontWantYourGreeting', 'JustSayOffff', '3:12', 2, 'DontWantYourGreeting.jpg'),
('LastStep', 'Hard', '3:10', 2, 'LastStep.jpg'),
('I7tilalMoshIst3mar', 'FireTrack', '3:58', 2, 'MaBa3dAlE7telal.jpg'),
('Ya Ramadan', 'No Comment', '3:16', 2, 'Ramadan.jpg'),

('7boobAlSa3adeh', 'addiction', '3:17', 3, '7boobAlSa3adeh.jpg'),
('BtejiBbali', 'Musical delight', '4:00', 3, 'BtejiBbali.jpg'),
('EgoBilKilo', 'Hard DesTrack ', '4:48', 3, 'EgoBilKilo.jpg'),
('Fifa', 'Auditory pleasure', '2:54', 3, 'Fifa.jpg'),
('MaBanam', 'Musical delight', '3:23', 3, 'MaBanam.jpg'),
('Turkwazi', 'Engaging entertainment ', '2:34', 3, 'Turkwazi.jpg'),

('Amrikkka', 'Sensory enjoyment', '3:26', 4, 'Amrikkka .jpg'),
('Kalbi', 'Captivating experience', '2:45', 4, 'Kalbi.png'),
('Mantika', 'Enjoyable listening', '4:13', 4, 'Mantika.jpg'),
('Marbah', 'Pleasurable sound ', '3:42', 4, 'Marbah.jpg'),
('Sindibad', 'Delightful tunes ', '3:04', 4, 'Sindibad.jpg'),
('WenWard ', 'Exciting content', '2:37', 4, 'WenWard.jpg'),

('Arouh', 'Your own private world', '2:53', 5, 'Arouh.jpg'),
('Kalamanji', 'Obsessive listening', '2:52', 5, 'Kalamanji.jpg'),
('MatkhaleshHadaAyesh', 'The lives of laborers', '3:52', 5, 'MatkhaleshHadaAyesh.jpg'),
('Qamarhen', 'Love', '3:48', 5, 'Qamarhen .jpg'),
('Radi', 'Calmness', '3:50', 5, 'Radi .jpg'),
('AlTawafan', 'JustRestartTheSong', '3:06', 5, 'TheSynaptik.jpg');


select * from Rapper;
select * from Track;