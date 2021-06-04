CREATE PROCEDURE [dbo].[GetStudentByGroup2]
	@Id int 
AS
select 
 [Id]
,[Name]
,[Surname]
,[Email]
,[Phone]
,[Git]
,[City]
,[Ranking]
,[AgreementNumber]

from [EJournalDB].[dbo].[Students] as S
left join [EJournalDB].[dbo].[GroupStudents] GS on S.Id = GS.IdStudents
where GS.IdGroup = @id and s.IsDelete = 0