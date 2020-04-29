CREATE VIEW [dbo].[Vehicle_view]
	AS SELECT IdVehicle, KindOfTheVehicle, UsefulLife, TechnicalCondition, LicensePlate, RegionName FROM dbo.[Vehicle] INNER JOIN Regions ON [Regions].IdRegion = [Vehicle].IdRegion
