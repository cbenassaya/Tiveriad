
using System;
namespace Tiveriad.Notifications.Applications.Errors;

public static class ErrorCodes
{
    public static string NotificationGetByIdQueryHandler_Id_XNotNullRule = "NotificationGetByIdQueryHandler_Id_XNotNullRule";
    public static string SubjectGetByIdQueryHandler_Id_XNotNullRule = "SubjectGetByIdQueryHandler_Id_XNotNullRule";
    public static string ScopeGetByIdQueryHandler_Id_XNotNullRule = "ScopeGetByIdQueryHandler_Id_XNotNullRule";
    public static string NotificationSaveCommandHandler_Notification_XNotNullRule = "NotificationSaveCommandHandler_Notification_XNotNullRule";
    public static string Notification_UserId_XNotEmptyRule = "Notification_UserId_XNotEmptyRule";
    public static string SubjectSaveCommandHandler_Subject_XNotNullRule = "SubjectSaveCommandHandler_Subject_XNotNullRule";
    public static string Subject_Name_XNotEmptyRule = "Subject_Name_XNotEmptyRule";
    public static string Subject_Name_XMaxLengthRule_Max_100 = "Subject_Name_XMaxLengthRule_Max_100";
    public static string Subject_Description_XNotNullRule = "Subject_Description_XNotNullRule";
    public static string ScopeSaveCommandHandler_Scope_XNotNullRule = "ScopeSaveCommandHandler_Scope_XNotNullRule";
    public static string NotificationUpdateCommandHandler_Notification_XNotNullRule = "NotificationUpdateCommandHandler_Notification_XNotNullRule";
    public static string Notification_Id_XNotNullRule = "Notification_Id_XNotNullRule";
    public static string SubjectUpdateCommandHandler_Subject_XNotNullRule = "SubjectUpdateCommandHandler_Subject_XNotNullRule";
    public static string Subject_Id_XNotNullRule = "Subject_Id_XNotNullRule";
    public static string ScopeUpdateCommandHandler_Scope_XNotNullRule = "ScopeUpdateCommandHandler_Scope_XNotNullRule";
    public static string Scope_Id_XNotNullRule = "Scope_Id_XNotNullRule";
    public static string NotificationDeleteCommandHandler_Id_XNotNullRule = "NotificationDeleteCommandHandler_Id_XNotNullRule";
    public static string SubjectDeleteCommandHandler_Id_XNotNullRule = "SubjectDeleteCommandHandler_Id_XNotNullRule";
    public static string ScopeDeleteCommandHandler_Id_XNotNullRule = "ScopeDeleteCommandHandler_Id_XNotNullRule";



}

