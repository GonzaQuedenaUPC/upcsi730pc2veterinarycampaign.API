﻿namespace upcsi730pc2veterinarycampaign.API.Crm.Interfaces.REST.Resources;

public record CreateManagerResource(string FirstName, string LastName, int Status, DateTime ApprovedAt, DateTime ReportedAt,
    DateTime ContactedAt, int AssignedSalesAgentId);