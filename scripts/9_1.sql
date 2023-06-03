USE [BD_PRUEBAS];
GO


-- =============================================
-- Datos creación
-- Autor: LUIS CHAVEZ
-- Descripción:	Retorna la información de todos los planes de pagos.
-- Version: 1.2
-- =============================================

CREATE OR ALTER PROCEDURE dbo.[CLIENTES_LISTAR] @I_USUARIO_AUT    NVARCHAR(100), 
                                                       @I_CODIGO_SISTEMA NVARCHAR(20),
                                                       ---
                                                       @I_CODIGO_POLIZA  NVARCHAR(50), 
                                                       @I_FECHA_INICIO   DATE, 
                                                       @I_FECHA_FIN      DATE,
                                                       ---
                                                       @O_RESULTADO_JSON NVARCHAR(MAX) OUTPUT, 
                                                       @O_EXITO          BIT OUTPUT, 
                                                       @O_MENSAJE        NVARCHAR(4000) OUTPUT, 
                                                       @O_CODIGO_ERROR   INT OUTPUT
AS
    BEGIN
        IF(@O_EXITO = 1
           OR @O_EXITO IS NULL)
            BEGIN
                SET @O_RESULTADO_JSON =
                (
                    SELECT *
                    FROM dbo.[T_PERSONA] FOR JSON PATH, INCLUDE_NULL_VALUES
                );
                IF(@O_RESULTADO_JSON IS NOT NULL)
                    BEGIN
                        SET @O_EXITO = 1;
                        SET @O_MENSAJE = 'Datos obtenidos correctamente.';
                        SET @O_CODIGO_ERROR = 0;
                END;
                    ELSE
                    BEGIN
                        SET @O_EXITO = 0;
                        SET @O_MENSAJE = 'La busqueda no retornó resultados.';
                        SET @O_CODIGO_ERROR = 0;
                END;
        END;
    END;