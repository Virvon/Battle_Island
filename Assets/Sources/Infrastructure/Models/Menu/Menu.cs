﻿namespace Assets.Sources.Infrastructure.Models
{
    public class Menu
    {
        private readonly SceneLoader _sceneLoader;

        public Menu() =>
            _sceneLoader = new();

        public void LoadScene(SceneId scene) =>
            _sceneLoader.Load(scene);
    }
}