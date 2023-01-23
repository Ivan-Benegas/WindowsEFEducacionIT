namespace WindowsEFForm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uno : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carrera",
                c => new
                    {
                        IDCarrera = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.IDCarrera);
            
            CreateTable(
                "dbo.Curso",
                c => new
                    {
                        IDCurso = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.IDCurso);
            
            CreateTable(
                "dbo.Detalle",
                c => new
                    {
                        IDDetalle = c.Int(nullable: false, identity: true),
                        IDPlanilla = c.Int(nullable: false),
                        IDEstado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDDetalle)
                .ForeignKey("dbo.Estado", t => t.IDEstado, cascadeDelete: true)
                .ForeignKey("dbo.Planilla", t => t.IDPlanilla, cascadeDelete: true)
                .Index(t => t.IDPlanilla)
                .Index(t => t.IDEstado);
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        IDEstado = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.IDEstado);
            
            CreateTable(
                "dbo.Planilla",
                c => new
                    {
                        IDPlanilla = c.Int(nullable: false, identity: true),
                        IDCarrera = c.Int(nullable: false),
                        IDMateria = c.Int(nullable: false),
                        IDProfesor = c.Int(nullable: false),
                        IDCurso = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDPlanilla)
                .ForeignKey("dbo.Carrera", t => t.IDCarrera, cascadeDelete: true)
                .ForeignKey("dbo.Curso", t => t.IDCurso, cascadeDelete: true)
                .ForeignKey("dbo.Materia", t => t.IDMateria, cascadeDelete: true)
                .ForeignKey("dbo.Profesor", t => t.IDProfesor, cascadeDelete: true)
                .Index(t => t.IDCarrera)
                .Index(t => t.IDMateria)
                .Index(t => t.IDProfesor)
                .Index(t => t.IDCurso);
            
            CreateTable(
                "dbo.Materia",
                c => new
                    {
                        IDMateria = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.IDMateria);
            
            CreateTable(
                "dbo.Profesor",
                c => new
                    {
                        IDProfesor = c.Int(nullable: false, identity: true),
                        IDLocalidad = c.Int(nullable: false),
                        Nombre = c.String(),
                        Apellido = c.String(),
                    })
                .PrimaryKey(t => t.IDProfesor)
                .ForeignKey("dbo.Localidad", t => t.IDLocalidad, cascadeDelete: true)
                .Index(t => t.IDLocalidad);
            
            CreateTable(
                "dbo.Localidad",
                c => new
                    {
                        IDLocalidad = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.IDLocalidad);
            
            CreateTable(
                "dbo.Estudiante",
                c => new
                    {
                        IDEstudiante = c.Int(nullable: false, identity: true),
                        IDLocalidad = c.Int(nullable: false),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Telefono = c.String(),
                        Calle = c.String(),
                        Numero = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDEstudiante)
                .ForeignKey("dbo.Localidad", t => t.IDLocalidad, cascadeDelete: true)
                .Index(t => t.IDLocalidad);
            
            CreateTable(
                "dbo.Evaluacion",
                c => new
                    {
                        IDEvaluacion = c.Int(nullable: false, identity: true),
                        IDTipo = c.Int(nullable: false),
                        IDEstudiante = c.Int(),
                        IDDetalle = c.Int(nullable: false),
                        Nota = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDEvaluacion)
                .ForeignKey("dbo.Detalle", t => t.IDDetalle, cascadeDelete: true)
                .ForeignKey("dbo.Estudiante", t => t.IDEstudiante)
                .ForeignKey("dbo.Tipo", t => t.IDTipo, cascadeDelete: true)
                .Index(t => t.IDTipo)
                .Index(t => t.IDEstudiante)
                .Index(t => t.IDDetalle);
            
            CreateTable(
                "dbo.Tipo",
                c => new
                    {
                        IDTipo = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.IDTipo);
            
            CreateTable(
                "dbo.Plan",
                c => new
                    {
                        IDPlan = c.Int(nullable: false, identity: true),
                        IDCarrera = c.Int(nullable: false),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.IDPlan)
                .ForeignKey("dbo.Carrera", t => t.IDCarrera, cascadeDelete: true)
                .Index(t => t.IDCarrera);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Plan", "IDCarrera", "dbo.Carrera");
            DropForeignKey("dbo.Evaluacion", "IDTipo", "dbo.Tipo");
            DropForeignKey("dbo.Evaluacion", "IDEstudiante", "dbo.Estudiante");
            DropForeignKey("dbo.Evaluacion", "IDDetalle", "dbo.Detalle");
            DropForeignKey("dbo.Estudiante", "IDLocalidad", "dbo.Localidad");
            DropForeignKey("dbo.Detalle", "IDPlanilla", "dbo.Planilla");
            DropForeignKey("dbo.Planilla", "IDProfesor", "dbo.Profesor");
            DropForeignKey("dbo.Profesor", "IDLocalidad", "dbo.Localidad");
            DropForeignKey("dbo.Planilla", "IDMateria", "dbo.Materia");
            DropForeignKey("dbo.Planilla", "IDCurso", "dbo.Curso");
            DropForeignKey("dbo.Planilla", "IDCarrera", "dbo.Carrera");
            DropForeignKey("dbo.Detalle", "IDEstado", "dbo.Estado");
            DropIndex("dbo.Plan", new[] { "IDCarrera" });
            DropIndex("dbo.Evaluacion", new[] { "IDDetalle" });
            DropIndex("dbo.Evaluacion", new[] { "IDEstudiante" });
            DropIndex("dbo.Evaluacion", new[] { "IDTipo" });
            DropIndex("dbo.Estudiante", new[] { "IDLocalidad" });
            DropIndex("dbo.Profesor", new[] { "IDLocalidad" });
            DropIndex("dbo.Planilla", new[] { "IDCurso" });
            DropIndex("dbo.Planilla", new[] { "IDProfesor" });
            DropIndex("dbo.Planilla", new[] { "IDMateria" });
            DropIndex("dbo.Planilla", new[] { "IDCarrera" });
            DropIndex("dbo.Detalle", new[] { "IDEstado" });
            DropIndex("dbo.Detalle", new[] { "IDPlanilla" });
            DropTable("dbo.Plan");
            DropTable("dbo.Tipo");
            DropTable("dbo.Evaluacion");
            DropTable("dbo.Estudiante");
            DropTable("dbo.Localidad");
            DropTable("dbo.Profesor");
            DropTable("dbo.Materia");
            DropTable("dbo.Planilla");
            DropTable("dbo.Estado");
            DropTable("dbo.Detalle");
            DropTable("dbo.Curso");
            DropTable("dbo.Carrera");
        }
    }
}
