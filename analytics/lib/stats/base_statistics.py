"""

"""

from ..base import Base, CLUSTER_NAME_COLUMN_LABEL

import pandas as pd

from statistics import mean

from scipy.stats import ttest_rel, ttest_ind, pearsonr, ttest_1samp
from math import sqrt
from numpy import std

SUM_PRE_CITATIONS_COLUMN_LABEL = "SumPreRawCitations"
SUM_POST_CITATIONS_COLUMN_LABEL = "SumPostRawCitations"

class BaseStatistics(Base):
    """
    TODO
    """
    
    @staticmethod
    def get_mean_of_raw_citations(publications, pre=True):
        """
        Computes the mean of citation counts of all the publications
        before or after (the `pre` argument) they were added to the repository. 

        :type   publications:   pandas.core.frame.DataFrame
        :param  publications:   A dataframe containing the publications.

        :type   pre:    boolean
        :param  pre:    If set to true   or false, respectively returns the mean of  
                        citations before or after the tools were added to the repository.

        :rtype:     float
        :return:    The mean of citations.
        """
        col = SUM_PRE_CITATIONS_COLUMN_LABEL if pre else SUM_POST_CITATIONS_COLUMN_LABEL
        return mean(publications[col])

    @staticmethod
    def ttest_avg_pre_post(publications):
        """
        Calculates the t-test on average citations before and after tools were
        added to the repository, with the null hypothesis that the two populations
        have identical mean. This method assumes the populations are related, and 
        the test is one-sided (i.e., t-statistic is always positive).

        :type   publications:   pandas.core.frame.DataFrame
        :param  publications:   A dataframe containing the publications. 
        
        :return: returns Cohen's d, it's interpretation, t-statistic of the t-test and it's p-value.
        """
        _, _, _, _, avg_pre, avg_post, _ = Base.get_vectors(publications)
        t_statistic, pvalue = ttest_rel(avg_pre, avg_post)
        return (BaseStatistics.cohen_d(avg_pre, avg_post)) + (abs(t_statistic), pvalue)

    @staticmethod
    def ttest_delta(publications, theoretical_mean=0.0):
        """
        Calculates the t-test for mean of differences between 
        before and after (delta) tools were added to the repository.

        This is a one-sided test (i.e., t-statistic is always positive)
        for the null hypothesis that the mean of deltas equals to the 
        given theoretical means.

        :type   publications:   pandas.core.frame.DataFrame
        :param  publications:   A dataframe containing the publications. 
        
        :type   theoretical_mean:   float
        :param  theoretical_mean:   Population mean before treatment. The default value is 0.0,
                                    which can be read as if the citation count has not changed
                                    after a tool was added to a repository.
                                    
        :return: returns Cohen's d, it's interpretation, t-statistic of the t-test and it's p-value.
        """
        _, _, _, _, _, _, delta = Base.get_vectors(publications)
        t_statistic, pvalue = ttest_1samp(delta, theoretical_mean)
        return (BaseStatistics.cohen_d(delta, theoretical_mean=theoretical_mean)) + (abs(t_statistic), pvalue)

    @staticmethod
    def ttest_deltas(publications_a, publications_b):
        _, _, _, _, _, _, delta_a = Base.get_vectors(publications_a)
        _, _, _, _, _, _, delta_b = Base.get_vectors(publications_b)

        t_statistic, pvalue = ttest_ind(delta_a, delta_b, equal_var=False)
        return (BaseStatistics.cohen_d(delta_a, delta_b)) + (abs(t_statistic), pvalue)

    @staticmethod
    def ttest_total_citations(publications_x, publications_y):
        """

        :type   publications_x: pandas.core.frame.DataFrame
        :param  publications_x: 

        :type   publications_y: pandas.core.frame.DataFrame
        :param  publications_y: 

        """
        _, _, _, sums_x, _, _, _ = Base.get_vectors(publications_x)
        _, _, _, sums_y, _, _, _ = Base.get_vectors(publications_y)
        t_statistic, pvalue = ttest_ind(sums_x, sums_y, equal_var=False)
        return (BaseStatistics.cohen_d(sums_x, sums_y)) + (abs(t_statistic), pvalue)

    @staticmethod
    def cohen_d(x, y=None, theoretical_mean=0.0):
        if len(x) < 2 or (y and len(y) < 2):
            return float('NaN'), "NaN"

        if y:
            # Cohen's d is computed as explained in the following link:
            # https://stackoverflow.com/a/33002123/947889
            d = len(x) + len(y) - 2
            cohen_d = (mean(x) - mean(y)) / sqrt(((len(x) - 1) * std(x) ** 2 + (len(y) - 1) * std(y) ** 2) / d)
        else:
            cohen_d = (mean(x) - theoretical_mean) / std(x)

        cohen_d = abs(cohen_d)

        # This interpretation is based on the info available on Wikipedia:
        # https://en.wikipedia.org/wiki/Effect_size#Cohen.27s_d
        if cohen_d >= 0.00 and cohen_d < 0.10:
            msg = "Very small"
        if cohen_d >= 0.10 and cohen_d < 0.35:
            msg = "Small"
        if cohen_d >= 0.35 and cohen_d < 0.65:
            msg = "Medium"
        if cohen_d >= 0.65 and cohen_d < 0.90:
            msg = "Large"
        if cohen_d >= 0.90:
            msg = "Very large"

        return cohen_d, msg + " effect size"
