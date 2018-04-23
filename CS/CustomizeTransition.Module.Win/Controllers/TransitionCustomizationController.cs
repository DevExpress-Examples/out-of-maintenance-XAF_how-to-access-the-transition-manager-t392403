using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Win.SystemModule;
using DevExpress.Utils.Animation;

namespace CustomizeTransition.Module.Win
{
public class TransitionCustomizationController : WindowController
{
    private OfficeNavBarTransitionController officeNavBarTransitionController;

    private void OnCustomizeTransition(object sender, CustomizeTransitionEventArgs e) {
        e.TransitionManager.Transitions[e.TransitionControl].TransitionType = new CombTransition();
    }
    protected override void OnActivated() {
        base.OnActivated();
        OfficeNavBarTransitionController officeNavBarTransitionController = Frame.GetController<OfficeNavBarTransitionController>();
        if(officeNavBarTransitionController != null) {
            officeNavBarTransitionController.CustomizeTransition += OnCustomizeTransition;
        }
    }
    protected override void OnDeactivated() {
        if(officeNavBarTransitionController != null) {
            officeNavBarTransitionController.CustomizeTransition -= OnCustomizeTransition;
        }
        base.OnDeactivated();
    }
    public TransitionCustomizationController() {
        TargetWindowType = WindowType.Main;
    }
}
}
