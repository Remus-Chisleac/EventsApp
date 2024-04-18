namespace EventsApp;

using EventsApp.Logic.Entities;
using EventsApp.Logic.Managers;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public partial class ReportPage : ContentPage
{
    private Guid userGuid;
    private Guid eventGuid;

    public ReportPage(Guid userGuid, Guid eventGuid)
    {
        InitializeComponent();
        this.userGuid = userGuid;
        this.eventGuid = eventGuid;
        BindingContext = this;
    }

    private void CloseButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private ReportInfo.ReportType GetFirstReportType()
    {
        if (SpamCB.IsChecked) return ReportInfo.ReportType.Spam;
        if (FraudCB.IsChecked) return ReportInfo.ReportType.Fraud;
        if (HarrasmentCB.IsChecked) return ReportInfo.ReportType.Harassment;
        if (OffensiveCB.IsChecked) return ReportInfo.ReportType.Offensive;
        if (ViolationsCB.IsChecked) return ReportInfo.ReportType.Violence;
        if (NudityCB.IsChecked) return ReportInfo.ReportType.Nudity;

        return ReportInfo.ReportType.None;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        ReportsManager.AddReport(userGuid, eventGuid, GetFirstReportType());
        Navigation.PopAsync();
    }
}