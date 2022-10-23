using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : Singleton<ScreenManager> {

    [SerializeField] List<ScreenBase> screenBases;
    [SerializeField] ScreenType startScreen = ScreenType.Panel;

    ScreenBase _currentScreen;

    void Start() {
        HideAll();
        ShowByType(startScreen);
    }

    void HideAll() {
        screenBases.ForEach(i => i.Hide());
    }

    public void ShowByType(ScreenType type) {
        if (_currentScreen != null) _currentScreen.Hide();
        var nextScreen = screenBases.Find(i => i.screenType == type);
        nextScreen.Show();
        _currentScreen = nextScreen;
    }
}
