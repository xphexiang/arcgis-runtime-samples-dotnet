// Copyright 2016 Esri.
//
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License.
// You may obtain a copy of the License at: http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an 
// "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific 
// language governing permissions and limitations under the License.

using Esri.ArcGISRuntime.Data;
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Symbology;
using System;
using System.Drawing;
using Windows.UI.Xaml;

namespace ArcGISRuntime.UWP.Samples.ChangeFeatureLayerRenderer
{
    [ArcGISRuntime.Samples.Shared.Attributes.Sample(
        "Change feature layer renderer",
        "Layers",
        "This sample demonstrates how to change renderer for a feature layer. It also shows how to reset the renderer back to the default.",
        "")]
    public partial class ChangeFeatureLayerRenderer
    {
        // Create and hold reference to the feature layer
        private FeatureLayer _featureLayer;

        public ChangeFeatureLayerRenderer()
        {
            InitializeComponent();

            // Setup the control references and execute initialization 
            Initialize();
        }

        private void Initialize()
        {
            // Create new Map with basemap
            Map myMap = new Map(Basemap.CreateTopographic());

            // Create and set initial map area
            Envelope initialLocation = new Envelope(
                -1.30758164047166E7, 4014771.46954516, -1.30730056797177E7, 4016869.78617381,
                SpatialReferences.WebMercator);

            // Set the initial viewpoint for map
            myMap.InitialViewpoint = new Viewpoint(initialLocation);

            // Provide used Map to the MapView
            MyMapView.Map = myMap;

            // Create uri to the used feature service
            Uri serviceUri = new Uri(
               "https://sampleserver6.arcgisonline.com/arcgis/rest/services/PoolPermits/FeatureServer/0");

            // Initialize feature table using a url to feature server url
            ServiceFeatureTable featureTable = new ServiceFeatureTable(serviceUri);

            // Initialize a new feature layer based on the feature table
            _featureLayer = new FeatureLayer(featureTable);
            myMap.OperationalLayers.Add(_featureLayer);
        }

        private void OnOverrideButtonClicked(object sender, RoutedEventArgs e)
        {
            // Create a symbol to be used in the renderer
            SimpleLineSymbol symbol = new SimpleLineSymbol()
            {
                Color = Color.Blue,
                Width = 2,
                Style = SimpleLineSymbolStyle.Solid
            };

            // Create a new renderer using the symbol just created
            SimpleRenderer renderer = new SimpleRenderer(symbol);

            // Assign the new renderer to the feature layer
            _featureLayer.Renderer = renderer;
        }

        private void OnResetButtonClicked(object sender, RoutedEventArgs e)
        {
            // Reset the renderer to default
            _featureLayer.ResetRenderer();
        }
    }
}
