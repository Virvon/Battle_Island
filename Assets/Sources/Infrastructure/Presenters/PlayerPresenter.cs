using UnityEngine;
using BattleIsland.Model;

public class PlayerPresenter
{
    private Player _model;
    private PlayerView _view;

    public PlayerPresenter(Player model, PlayerView view)
    {
        _model = model;
        _view = view;
    }

    public void Enable()
    {
        _model.Rotated += OnRotated;
        _model.Moved += OnMoved;

        _view.InputedRotation += OnTryRotate;
    }

    public void Disable()
    {
        _model.Rotated -= OnRotated;
        _model.Moved -= OnMoved;

        _view.InputedRotation -= OnTryRotate;
    }

    private void OnTryRotate(Vector2 direction) =>
        _model.Rotate(direction, Time.deltaTime);

    private void OnRotated() => 
        _view.Rotate(_model.Rotation);

    private void OnMoved() =>
        _view.Move(_model.Velocity);
}
