using AutoMapper;
using AutoMapper.QueryableExtensions;
using HealthCare.Framework.Paging;

namespace HealthCare.Framework.Mapper
{
    public class Mapper : Profile
    {
        private static IMapper Configs<TEntity, TDto>()
        {
            var config = new MapperConfiguration(p =>
            {
                p.CreateMap<TEntity, TDto>().ReverseMap();
                p.CreateMap<PagedQueryResult<TEntity>, PagedQueryResult<TDto>>().ReverseMap();
            });

            return config.CreateMapper();
        }

        private static IMapper Configs<TEntity, TDto, TEntityInner, TDtoInner>()
        {
            var config = new MapperConfiguration(p =>
            {
                p.CreateMap<TEntity, TDto>().ReverseMap();
                p.CreateMap<TEntityInner, TDtoInner>().ReverseMap();
                p.CreateMap<PagedQueryResult<TEntity>, PagedQueryResult<TDto>>().ReverseMap();
            });

            return config.CreateMapper();
        }

        public static TDTO Map<TEntity, TDTO>(TEntity entity)
        {
            return Configs<TEntity, TDTO>().Map<TDTO>(entity);
        }

        public static List<TDTO> Map<TEntity, TDTO>(List<TEntity> entity)
        {
            var config = new MapperConfiguration(p =>
            {
                p.CreateMap<TEntity, TDTO>();
            });

            return entity.AsQueryable().ProjectTo<TDTO>(config).ToList();
        }

        public static List<TDTO> Map<TEntity, TDTO, TEntityINNER, TDTOINNER>(List<TEntity> entity)
        {
            var config = new MapperConfiguration(p =>
            {
                p.CreateMap<TEntity, TDTO>();
                p.CreateMap<TEntityINNER, TDTOINNER>().ReverseMap();
            });

            return entity.AsQueryable().ProjectTo<TDTO>(config).ToList();
        }

        public static List<TDTO> Map<TEntity, TDTO, TEntityINNER, TDTOINNER, TEntityINNER2, TDTOINNER2>(List<TEntity> entity)
        {
            var config = new MapperConfiguration(p =>
            {
                p.CreateMap<TEntity, TDTO>();
                p.CreateMap<TEntityINNER, TDTOINNER>().ReverseMap();
                p.CreateMap<TEntityINNER2, TDTOINNER2>().ReverseMap();
            });

            return entity.AsQueryable().ProjectTo<TDTO>(config).ToList();
        }

        public static List<TDTO> Map<TEntity, TDTO, TEntityINNER, TDTOINNER, TEntityINNER2, TDTOINNER2, TEntityINNER3, TDTOINNER3>(List<TEntity> entity)
        {
            var config = new MapperConfiguration(p =>
            {
                p.CreateMap<TEntity, TDTO>();
                p.CreateMap<TEntityINNER, TDTOINNER>().ReverseMap();
                p.CreateMap<TEntityINNER2, TDTOINNER2>().ReverseMap();
                p.CreateMap<TEntityINNER3, TDTOINNER3>().ReverseMap();
            });

            return entity.AsQueryable().ProjectTo<TDTO>(config).ToList();
        }

        public static List<TDTO> Map<TEntity, TDTO, TEntityINNER, TDTOINNER, TEntityINNER2, TDTOINNER2, TEntityINNER3, TDTOINNER3, TEntityINNER4, TDTOINNER4>(List<TEntity> entity)
        {
            var config = new MapperConfiguration(p =>
            {
                p.CreateMap<TEntity, TDTO>();
                p.CreateMap<TEntityINNER, TDTOINNER>().ReverseMap();
                p.CreateMap<TEntityINNER2, TDTOINNER2>().ReverseMap();
                p.CreateMap<TEntityINNER3, TDTOINNER3>().ReverseMap();
                p.CreateMap<TEntityINNER4, TDTOINNER4>().ReverseMap();

            });

            return entity.AsQueryable().ProjectTo<TDTO>(config).ToList();
        }

        public static PagedQueryResult<TDTO> Map<TEntity, TDTO>(PagedQueryResult<TEntity> entity)
        {
            return Configs<TEntity, TDTO>().Map<PagedQueryResult<TDTO>>(entity);
        }

        public static PagedQueryResult<TDTO> Map<TEntity, TDTO, TEntityINNER, TDTOINNER>(PagedQueryResult<TEntity> entity)
        {
            return Configs<TEntity, TDTO, TEntityINNER, TDTOINNER>().Map<PagedQueryResult<TDTO>>(entity);
        }

        public static PagedQueryResult<TDTO> Map<TEntity, TDTO, TEntityINNER, TDTOINNER, TEntityINNER2, TDTOINNER2>(PagedQueryResult<TEntity> entity)
        {
            var config = new MapperConfiguration(p =>
            {
                p.CreateMap<TEntity, TDTO>().ReverseMap();
                p.CreateMap<TEntityINNER, TDTOINNER>().ReverseMap();
                p.CreateMap<TEntityINNER2, TDTOINNER2>().ReverseMap();
                p.CreateMap<PagedQueryResult<TEntity>, PagedQueryResult<TDTO>>().ReverseMap();
            });

            var mapping = config.CreateMapper();

            return mapping.Map<PagedQueryResult<TDTO>>(entity);
        }

        public static PagedQueryResult<TDTO> Map<TEntity, TDTO, TEntityINNER, TDTOINNER, TEntityINNER2, TDTOINNER2, TEntityINNER3, TDTOINNER3>(PagedQueryResult<TEntity> entity)
        {
            var config = new MapperConfiguration(p =>
            {
                p.CreateMap<TEntity, TDTO>().ReverseMap();
                p.CreateMap<TEntityINNER, TDTOINNER>().ReverseMap();
                p.CreateMap<TEntityINNER2, TDTOINNER2>().ReverseMap();
                p.CreateMap<TEntityINNER3, TDTOINNER3>().ReverseMap();
                p.CreateMap<PagedQueryResult<TEntity>, PagedQueryResult<TDTO>>().ReverseMap();
            });

            var mapping = config.CreateMapper();

            return mapping.Map<PagedQueryResult<TDTO>>(entity);
        }

        public static PagedQueryResult<TDTO> Map<TEntity, TDTO, TEntityINNER, TDTOINNER, TEntityINNER2, TDTOINNER2, TEntityINNER3, TDTOINNER3, TEntityINNER4, TDTOINNER4>(PagedQueryResult<TEntity> entity)
        {
            var config = new MapperConfiguration(p =>
            {
                p.CreateMap<TEntity, TDTO>().ReverseMap();
                p.CreateMap<TEntityINNER, TDTOINNER>().ReverseMap();
                p.CreateMap<TEntityINNER2, TDTOINNER2>().ReverseMap();
                p.CreateMap<TEntityINNER3, TDTOINNER3>().ReverseMap();
                p.CreateMap<TEntityINNER4, TDTOINNER4>().ReverseMap();
                p.CreateMap<PagedQueryResult<TEntity>, PagedQueryResult<TDTO>>().ReverseMap();
            });

            var mapping = config.CreateMapper();

            return mapping.Map<PagedQueryResult<TDTO>>(entity);
        }

        public static TDTO Map<TEntity, TDTO, TEntityINNER, TDTOINNER, TEntityINNER2, TDTOINNER2>(TEntity entity)
        {
            var config = new MapperConfiguration(p =>
            {
                p.CreateMap<TEntity, TDTO>().ReverseMap();
                p.CreateMap<TEntityINNER, TDTOINNER>().ReverseMap();
                p.CreateMap<TEntityINNER2, TDTOINNER2>().ReverseMap();
            });

            var mapping = config.CreateMapper();

            return mapping.Map<TDTO>(entity);
        }

        public static TDTO Map<TEntity, TDTO, TEntityINNER, TDTOINNER, TEntityINNER2, TDTOINNER2, TEntityINNER3, TDTOINNER3>(TEntity entity)
        {
            var config = new MapperConfiguration(p =>
            {
                p.CreateMap<TEntity, TDTO>().ReverseMap();
                p.CreateMap<TEntityINNER, TDTOINNER>().ReverseMap();
                p.CreateMap<TEntityINNER2, TDTOINNER2>().ReverseMap();
                p.CreateMap<TEntityINNER3, TDTOINNER3>().ReverseMap();
            });

            var mapping = config.CreateMapper();

            return mapping.Map<TDTO>(entity);
        }
        public static TDTO Map<TEntity, TDTO, TEntityINNER, TDTOINNER, TEntityINNER2, TDTOINNER2, TEntityINNER3, TDTOINNER3, TEntityINNER4, TDTOINNER4>(TEntity entity)
        {
            var config = new MapperConfiguration(p =>
            {
                p.CreateMap<TEntity, TDTO>().ReverseMap();
                p.CreateMap<TEntityINNER, TDTOINNER>().ReverseMap();
                p.CreateMap<TEntityINNER2, TDTOINNER2>().ReverseMap();
                p.CreateMap<TEntityINNER3, TDTOINNER3>().ReverseMap();
                p.CreateMap<TEntityINNER4, TDTOINNER4>().ReverseMap();
            });

            var mapping = config.CreateMapper();

            return mapping.Map<TDTO>(entity);
        }

        public static TDTO Map<TEntity, TDTO, TEntityINNER, TDTOINNER>(TEntity entity)
        {
            return Configs<TEntity, TDTO, TEntityINNER, TDTOINNER>().Map<TDTO>(entity);
        }

        //internal static class MapperExtension
        //{
        //    public static IMappingExpression<TSource, TDestination> IgnoreAllNonExisting<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
        //    {
        //        var flags = BindingFlags.Public | BindingFlags.Instance;
        //        var sourceType = typeof(TSource);
        //        var destinationProperties = typeof(TDestination).GetProperties(flags);

        //        foreach (var property in destinationProperties)
        //        {
        //            if (sourceType.GetProperty(property.Name, flags) == null)
        //            {
        //                expression.ForMember(property.Name, opt => opt.Ignore());
        //            }
        //        }
        //        return expression;
        //    }
        //}
    }
}
