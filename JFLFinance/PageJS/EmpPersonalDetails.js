
//$(document).ready(grid_CustomizationWindowCloseUp(s, e), button1_Click(s, e));

    function UpdateButtonText() {

        var text = grid.IsCustomizationWindowVisible() ? "Hide" : "Show";
        text += " Customization Window";
        button1.SetText(text);
    }

    function grid_CustomizationWindowCloseUp(s, e) {
        UpdateButtonText();
    }

    function button1_Click(s, e) {

        if (grid.IsCustomizationWindowVisible()) {
            grid.HideCustomizationWindow();
        }
        else {
            grid.ShowCustomizationWindow();
        }
        UpdateButtonText();
    }

