CREATE PROCEDURE AddHomeWork
@SRS nvarchar (255),
@Deadline datetime,
@IdGroup int
   AS
   insert into HomeWorks (SRS, Deadline, IdGroup)
   values(@SRS, @Deadline, @IdGroup)
