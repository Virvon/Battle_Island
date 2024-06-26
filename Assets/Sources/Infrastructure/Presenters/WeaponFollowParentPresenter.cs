using Assets.Sources.Infrastructure.Models;
using Assets.Sources.Infrastructure.Views.Weapon;

namespace Assets.Sources.Infrastructure.Presenters
{
    public class WeaponFollowParentPresenter
    {
        private Weapon _model;
        private WeaponFollowParentView _view;

        public WeaponFollowParentPresenter(Weapon model, WeaponFollowParentView view)
        {
            _model = model;
            _view = view;
        }

        public void Enable()
        {
            _model.PositionChanged += OnPositionChanged;

            _view.ParentPositionChanged += TryChangePosition;
        }

        public void Disable()
        {
            _model.PositionChanged -= OnPositionChanged;

            _view.ParentPositionChanged -= TryChangePosition;
        }

        private void OnPositionChanged() =>
            _view.ChangePosition();

        private void TryChangePosition() =>
            _model.TryChangePosition();
    }
}