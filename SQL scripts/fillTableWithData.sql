USE [DiplomDatabase]
GO

INSERT INTO [Action]  (Name, ShortDescription)
VALUES ('������� ������������', '�������� ������� ������������ � ����������'),
('����������', '�������� ���������� ����������'),
('��������', '�������� �� ��� ���������� ����������');

INSERT INTO Company (Name, ShortName, Address, ContactDetails)
VALUES ('��-��� ����', 'ISYS', '�.��������, ��. ������������28, ���� 304', '����: www.isys.ru, �����: +7(901)-184-37-80');


INSERT INTO Subdivision (Name, ShortName)
VALUES ('����������� ������ �������', '������ �������'),
('����������� �������� 1�', '1�'),
('����������� ����������� ���������', '����������� ���������');

INSERT INTO Position (Name, ShortDescription)
VALUES ('Software Production Business Unit Manager', '������������ ������ ������������ ������������ �����������'),
('Software Development Engineer', '������� �� ���������� ������������ �����������'),
('Senior Software Development Engineer', '������� ������� �� ���������� ������������ �����������'),
('����������� ��������', '����������� ��������'),
('Software Development Engineer', '������� �� ���������� ������������ �����������'),
('Junior Software Development Engineer', '������� ������� �� ���������� ������������ �����������'),
('���������', '���������');

INSERT INTO DocumentType(Name, ShortDescription)
VALUES ('txt', '��������� ������ ���������'),
('doc', '���������� ������ ����������'),
('pdf', ' ���������������� �������� ������ ����������� ����������'),
('xls', '������ ��� ������ � ������������ ���������');

INSERT INTO Network(Name, ShortDiscription, CompanyID)
VALUES ('���� 1', '���� ��� ������� 1', '1'),
('���� 2', '���� ��� ������� 2', '1'),
('���� 3', '���� ��� ������� 3', '1'),
('���� 4', '���� ��� ������� 4', '1');

INSERT INTO Document(Name, ShortDiscription, CreationDate, Path, Status, Size, EditsAndChanges, DocumentTypeID)
VALUES ('�������� ����� 1', '�������� ��� ������� 1', '2019-01-18T11:19:00.000', '�:\Documents\Document1', 'Edit', '500', 'No Edits', '1'),
('�������� ����� 2', '�������� ��� ������� 2', '2019-01-19T11:19:00.000', '�:\Documents\Document2', 'Apply', '320', 'No Edits', '2'),
('�������� ����� 3', '�������� ��� ������� 3', '2019-01-20T11:19:00.000', '�:\Documents\Document3', 'Reject', '480', 'No Edits', '3'),
('�������� ����� 4', '�������� ��� ������� 4', '2019-01-21T11:19:00.000', '�:\Documents\Document4', 'Edit', '761', 'No Edits', '4');

INSERT INTO RoutePoint(Name, ShortDescription, StageNumber, DocumentTypeID, PositionID, ActionID)
VALUES ('������� 1', '������� ��� ������� 1', '���� 1', '1', '1', '1'),
('������� 2', '������� ��� ������� 2', '���� 2', '2', '2', '2'),
('������� 3', '������� ��� ������� 3', '���� 3', '3', '3', '3'),
('������� 4', '������� ��� ������� 4', '���� 4', '4', '4', '1');

INSERT INTO SecurityInformation(Name, ShortDescription, HashSize, DocumentID)
VALUES ('���������� 1', '���������� ��� ������� 1', '789', '3'),
('���������� 2', '���������� ��� ������� 2', '875', '4'),
('���������� 3', '���������� ��� ������� 3', '561', '5'),
('���������� 4', '���������� ��� ������� 4', '789', '6');

INSERT INTO MonitoringInformation(Name, ShortDescription, DocumentID, NetworkID)
VALUES ('������� 1', '������� ��� ������� 1', '3', '1'),
('������� 2', '������� ��� ������� 2', '4', '2'),
('������� 3', '������� ��� ������� 3', '5', '3'),
('������� 4', '������� ��� ������� 4', '6', '4');

INSERT INTO Employee(Name, Surname, MiddleName, TelephoneNumber, Email, PositionID, SubdivisionID, CompanyID)
VALUES ('���1', '�������1', '��������1', '89013126411', 'mail1@mail.ru', '1', '1', '1'),
('���2', '�������2', '��������2', '89013126412', 'mail2@mail.ru', '2', '2', '1'),
('���3', '�������3', '��������3', '89013126413', 'mail3@mail.ru', '3', '3', '1'),
('���4', '�������4', '��������4', '89013126414', 'mail4@mail.ru', '4', '1', '1');

INSERT INTO DocumentPathHistory(Name, DateAndTimeOfDispatch, DocumentID, EmployeeID)
VALUES ('������� ���� 1', '2019-01-20T11:19:00.000', '3', '1'),
('������� ���� 1', '2019-01-18T11:17:00.000', '4', '2'),
('������� ���� 1', '2019-01-18T11:15:00.000', '5', '3'),
('������� ���� 1', '2019-01-18T11:13:00.000', '6', '4');