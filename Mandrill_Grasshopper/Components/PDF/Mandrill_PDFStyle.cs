﻿using System;
using Grasshopper.Kernel;
using Mandrill_Resources.Properties;
using D3jsLib;

namespace Mandrill_Grasshopper.Components.PDF
{
    public class Mandrill_PDFStyle : GH_Component
    {
        /// <summary>
        /// Initializes a new instance of the Mandrill_PDFStyle class.
        /// </summary>
        public Mandrill_PDFStyle()
          : base("PdfStyle", "Style",
              "Pdf Style object.",
              Resources.CategoryName, Resources.SubCategoryPDF)
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddTextParameter("pdfSize", "S", Resources.Style_PdfSizeDesc, GH_ParamAccess.item, "28");
            pManager.AddTextParameter("pdfOrientation", "O", Resources.Style_PdfOrientationDesc, GH_ParamAccess.item, "1");
            pManager.AddTextParameter("pdfHorizontalFit", "HF", Resources.Style_PdfHorizontalFitDesc, GH_ParamAccess.item, "2");
            pManager.AddTextParameter("pdfVerticalFit", "VF", Resources.Style_PdfVerticalFitDesc, GH_ParamAccess.item, "2");
            pManager.AddIntegerParameter("compression", "C", Resources.Style_CompressionDesc, GH_ParamAccess.item, 10);
            pManager.AddIntegerParameter("marginTop", "MT", Resources.Style_MarginDesc, GH_ParamAccess.item, 0);
            pManager.AddIntegerParameter("marginRight", "MR", Resources.Style_MarginDesc, GH_ParamAccess.item, 0);
            pManager.AddIntegerParameter("marginBottom", "MB", Resources.Style_MarginDesc, GH_ParamAccess.item, 0);
            pManager.AddIntegerParameter("marginLeft", "ML", Resources.Style_MarginDesc, GH_ParamAccess.item, 0);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddGenericParameter("Style", "S", Resources.PDF_StyleDesc, GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            string size = "28";
            string orientation = "1";
            string horizontalFit = "2";
            string verticalFit = "2";
            int compression = 10;
            int marginTop = 0;
            int marginRight = 0;
            int marginBottom = 0;
            int marginLeft = 0;

            DA.GetData<string>(0, ref size);
            DA.GetData<string>(1, ref orientation);
            DA.GetData<string>(2, ref horizontalFit);
            DA.GetData<string>(3, ref verticalFit);
            DA.GetData<int>(4, ref compression);
            DA.GetData<int>(5, ref marginTop);
            DA.GetData<int>(6, ref marginRight);
            DA.GetData<int>(7, ref marginBottom);
            DA.GetData<int>(8, ref marginLeft);

            PdfStyle style = new PdfStyle();
            style.Size = (SelectPdf.PdfPageSize)int.Parse(size);
            style.Orientation = (SelectPdf.PdfPageOrientation)int.Parse(orientation);
            style.VerticalFit = (SelectPdf.HtmlToPdfPageFitMode)int.Parse(verticalFit);
            style.HorizontalFit = (SelectPdf.HtmlToPdfPageFitMode)int.Parse(horizontalFit);
            style.Compression = compression;
            style.MarginTop = marginTop;
            style.MarginRight = marginRight;
            style.MarginBottom = marginBottom;
            style.MarginLeft = marginLeft;

            DA.SetData(0, style);
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return Resources.Report_Pdf_Style;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("{906bbc4d-86aa-41a2-81d8-5fa8ac8033a0}"); }
        }
    }
}