CREATE PROCEDURE [dbo].[GetStudentByGroup]
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

from [dbo].[Students] as S
left join [dbo].[GroupStudents] GS on S.Id = GS.IdStudents
where GS.IdGroup = @Id and s.IsDelete = 0