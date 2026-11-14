# EMPLANIAPP | Validación para portafolio

Este checklist separa las capacidades observadas en el **código fuente** de pruebas funcionales todavía pendientes.

## Preparación local

- [ ] Compilar los cuatro proyectos de `Emplaniapp.sln` en Visual Studio 2022 con .NET Framework 4.8.1.
- [ ] Configurar una base SQL Server exclusivamente con **datos ficticios**.
- [ ] Recuperar/documentar el esquema SQL sin contraseñas ni información real.
- [ ] Preparar un usuario ficticio para cada rol que se quiera probar.

## Pruebas funcionales

- [ ] Login, logout y recuperación de contraseña con cuenta de correo de prueba.
- [ ] Autorización de pantallas y acciones para Administrador, Contador y Empleado.
- [ ] Altas, consultas, filtros y cambios de estado de empleados.
- [ ] Alta/edición de remuneraciones y retenciones.
- [ ] Generación y aprobación de hoja resumen de planilla.
- [ ] Recibos y reportes PDF con datos inventados.
- [ ] Liquidaciones e historial de cambios.
- [ ] Panel de indicadores con datos coherentes.
- [ ] Revisión visual de formularios, errores y menú móvil.

## Seguridad: obligatorio antes de uso remoto

- [ ] **Revocar/rotar la contraseña SMTP anteriormente versionada** en `Web.config`; sigue expuesta en el historial del repositorio público.
- [ ] Configurar `EMPLANIAPP_SMTP_USERNAME` y `EMPLANIAPP_SMTP_PASSWORD` fuera de Git.
- [ ] Confirmar que ninguna cadena SQL, contraseña, token o correo personal se publica en capturas o en Git.
- [ ] Confirmar que `customErrors` no está deshabilitado para clientes remotos.
- [ ] Revisar autenticación, permisos, cookies, política de contraseñas y rutas sensibles.
- [ ] Evaluar las dependencias NuGet y sus avisos de seguridad antes de desplegar.
- [ ] Validar cumplimiento funcional con la normativa de nómina aplicable si se quisiera usar comercialmente.

## Capturas a incorporar (sin datos reales)

Guardar en `docs/screenshots/` después de tomar capturas reales:

1. Pantalla de acceso.
2. Dashboard.
3. Lista de empleados.
4. Gestión de remuneraciones/retenciones.
5. Hoja resumen y aprobación.
6. Recibo o informe PDF ficticio.

**No inventar capturas ni subir datos identificables.** Este repositorio no contiene por ahora un proyecto de tests ni scripts SQL completos para una instalación desde cero.
