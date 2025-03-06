using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionModel
{
    public bool IsInitialized { get; private set; }

    public Context Context { get; private set; }

    public List<ResourceModel> ResourceModels { get { return _resourceModels; } }

    private List<ResourceModel> _resourceModels = new List<ResourceModel>();

    public void Initialize(Context context)
    {
        if (!IsInitialized)
        {
            IsInitialized = true;
            Context = context;

            ResourceModel oil = new ResourceModel(1, "Нефть", "млн.т/мес", 29.42f, 20.84f, 1150, 4000000);
            ResourceModel gaz = new ResourceModel(2, "Газ", "млрд.куб.м/мес", 16.5f, 11.97f, 350, 5000000);
            ResourceModel gold = new ResourceModel(3, "Золото", "т/мес", 16.7f, 4.67f, 230, 25000000);
            ResourceModel metal = new ResourceModel(4, "Метал", "млн.т/мес", 16.83f, 16.25f, 1300, 50000000);
            ResourceModel food = new ResourceModel(5, "Еда", "млн.т/мес", 8.95f, 9.78f, 4500, 400000000);
            ResourceModel electricity = new ResourceModel(6, "Электричество", "млрд.квт.ч/мес", 61.74f, 60.86f, 1700, 5000000);
            ResourceModel coal = new ResourceModel(7, "Уголь", "млн.т/мес", 52f, 44.17f, 2300, 7000000);
            ResourceModel forest = new ResourceModel(8, "Лес", "млн.куб.м/мес", 24.92f, 24.92f, 2300, 6000000);
            ResourceModel goods = new ResourceModel(9, "Товар", "шт/мес", 0f, 0f, 0, 0);

            _resourceModels.Add(oil);
            _resourceModels.Add(gaz);
            _resourceModels.Add(gold);
            _resourceModels.Add(metal);
            _resourceModels.Add(food);
            _resourceModels.Add(electricity);
            _resourceModels.Add(coal);
            _resourceModels.Add(forest);
            _resourceModels.Add(goods);
        }
    }

    public void ChangeResourceProduction(int resourceId, int expense, float inflation, float corruption)
    {
        float investment = expense * (1 - inflation / 100) * (1 - corruption / 100); //Пока хз
        ResourceModel resourceModel = GetResourceModelById(resourceId);
        
        float change = (float) (investment / (resourceModel.Production * resourceModel.CostPrice));
            //Рост потребления людских ресурсов и электричества
        if (change > 1)
        {
        } else if (change == 1)
        {
        } else
        {
            change = ((resourceModel.Production * resourceModel.CostPrice) - investment * (1 - change)) * -1;
        }
        resourceModel.ChangeProduction((float) ((1 + change / 100) * resourceModel.Production));
    }

    public ResourceModel GetResourceModelById(int resourceId)
    {
        foreach(ResourceModel resourceModel in _resourceModels)
        {
            if (resourceModel.Id == resourceId)
            {
                return resourceModel;
            }
        }
        return null;
    }
}
