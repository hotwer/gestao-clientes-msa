namespace GestaoClientesMSA.Controllers.Mappers
{
    public interface IMapper<TModel, TDto>
    {
        public void Map(TDto dto, TModel model);

        public void Map(TModel model, TDto dto);
    }

}
