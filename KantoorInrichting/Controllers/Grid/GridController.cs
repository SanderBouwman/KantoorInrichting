using KantoorInrichting.Models.Grid;

namespace KantoorInrichting.Controllers.Grid {

    public class GridController {

        private GridFieldView _view;
        private GridFieldModel _model;

        public GridController(GridFieldView view, GridFieldModel model) {
            _view = view;
            _model = model;

            _view.setController(this);
        }
    }
}