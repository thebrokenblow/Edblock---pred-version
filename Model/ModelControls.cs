using System.Collections.Generic;

namespace Flowchart_Editor.Model
{
    public class ModelControls
    {
        public List<BlockModel>? listBlockModels { get; private set; }
        public List<LineModel>? listLineModels { get; private set; }
        public StyleModel styleModel { get; private set; }
        public ModelControls(List<BlockModel> listBlockModels, List<LineModel> listLineModels, StyleModel styleModel)
        {
            this.listBlockModels = listBlockModels;
            this.listLineModels = listLineModels;
            this.styleModel = styleModel;
        }
    }
}
