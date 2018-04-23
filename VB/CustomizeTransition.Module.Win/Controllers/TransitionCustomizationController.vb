Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Win.SystemModule
Imports DevExpress.Utils.Animation

Namespace CustomizeTransition.Module.Win
Public Class TransitionCustomizationController
    Inherits WindowController

    Private officeNavBarTransitionController As OfficeNavBarTransitionController

    Private Sub OnCustomizeTransition(ByVal sender As Object, ByVal e As CustomizeTransitionEventArgs)
        e.TransitionManager.Transitions(e.TransitionControl).TransitionType = New CombTransition()
    End Sub
    Protected Overrides Sub OnActivated()
        MyBase.OnActivated()
        Dim officeNavBarTransitionController As OfficeNavBarTransitionController = Frame.GetController(Of OfficeNavBarTransitionController)()
        If officeNavBarTransitionController IsNot Nothing Then
            AddHandler officeNavBarTransitionController.CustomizeTransition, AddressOf OnCustomizeTransition
        End If
    End Sub
    Protected Overrides Sub OnDeactivated()
        If officeNavBarTransitionController IsNot Nothing Then
            RemoveHandler officeNavBarTransitionController.CustomizeTransition, AddressOf OnCustomizeTransition
        End If
        MyBase.OnDeactivated()
    End Sub
    Public Sub New()
        TargetWindowType = WindowType.Main
    End Sub
End Class
End Namespace
