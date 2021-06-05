CREATE PROCEDURE UpdateHomeWork
@Id int,
@SRS nvarchar (255),
@Deadline datetime,
@IdGroup int
   AS
   update HomeWorks
   set SRS = @SRS, Deadline = @Deadline, IdGroup = @IdGroup
   where Id = @Id