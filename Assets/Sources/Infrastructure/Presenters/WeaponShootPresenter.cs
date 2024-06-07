using UnityEngine;
using BattleIsland.Model;

public class WeaponShootPresenter
{
    private Weapon _model;
    private WeaponShootView _view;

    public WeaponShootPresenter(Weapon model, WeaponShootView view)
    {
        _model = model;
        _view = view;
    }

    public void Enable()
    {
        _model.Shotted += OnShotted;
        _model.Comeback += OnComeback;
        _model.TrajectoryChanged += ChangeTrajectory;

        _view.Shotted += TryShoot;
        _view.Comebacked += TryComeback;
        _view.StateChanged += OnStateChanged;
        _view.CollisionEntered += ChangeTrajectory;
    }

    public void Disable()
    {
        _model.Shotted -= OnShotted;
        _model.Comeback -= OnComeback;
        _model.TrajectoryChanged -= ChangeTrajectory;

        _view.Shotted -= TryShoot;
        _view.Comebacked -= TryComeback;
        _view.StateChanged -= OnStateChanged;
        _view.CollisionEntered -= ChangeTrajectory;
    }

    private void ChangeTrajectory(Vector3 forward, Vector3 normal) => 
        _model.ChangeTrajectory(forward, normal);

    private void ChangeTrajectory(Vector3 resultDirection) => 
        _view.ChangeTrajectory(resultDirection);

    private void TryShoot() => 
        _model.TryShoot();

    private void TryComeback() => 
        _model.TryComeback();

    private void OnShotted() => 
        _view.Shoot();

    private void OnComeback() => 
        _view.Comeback();

    private void OnStateChanged(State state) =>
        _model.SetState(state);
}